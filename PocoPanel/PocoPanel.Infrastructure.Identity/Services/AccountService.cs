using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
using PocoPanel.Application.DTOs.Account;
using PocoPanel.Application.DTOs.Email;
using PocoPanel.Application.Enums;
using PocoPanel.Application.Exceptions;
using PocoPanel.Application.Interfaces;
using PocoPanel.Application.Wrappers;
using PocoPanel.Domain.Entities;
using PocoPanel.Domain.Settings;
using PocoPanel.Infrastructure.Identity.Helpers;
using PocoPanel.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PocoPanel.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailService _emailService;
        private readonly JWTSettings _jwtSettings;
        private readonly IDateTimeService _dateTimeService;
        private readonly IGetInfo _GetInfo;
        private readonly IGetUser _GetUser;
        private readonly IViewRenderService _ViewRenderService;
        public AccountService(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptions<JWTSettings> jwtSettings,
            IDateTimeService dateTimeService,
            SignInManager<ApplicationUser> signInManager,
            IEmailService emailService,
            IGetInfo getInfo,
            IGetUser getUser,
            IViewRenderService viewRenderService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtSettings = jwtSettings.Value;
            _dateTimeService = dateTimeService;
            _signInManager = signInManager;
            this._emailService = emailService;
            _GetInfo = getInfo;
            _GetUser = getUser;
            _ViewRenderService = viewRenderService;


        }

        public async Task<Response<AuthenticationResponse>> AuthenticateAsync(AuthenticationRequest request, string ipAddress)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                throw new ApiException($"No Accounts Registered with {request.Email}.");
            }
            var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                throw new ApiException($"Invalid Credentials for '{request.Email}'.");
            }
            if (!user.EmailConfirmed)
            {
                throw new ApiException($"Account Not Confirmed for '{request.Email}'.");
            }
            JwtSecurityToken jwtSecurityToken = await GenerateJWToken(user);
            AuthenticationResponse response = new AuthenticationResponse();
            response.Id = user.Id;
            response.JWToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            response.Email = user.Email;
            response.UserName = user.UserName;
            var rolesList = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            response.Roles = rolesList.ToList();
            response.IsVerified = user.EmailConfirmed;
            var refreshToken = GenerateRefreshToken(ipAddress);
            response.RefreshToken = refreshToken.Token;
            response.PublicCode = user.PublicCode;
            response.PublicToken = user.ApiToken;
            response.FirstName = user.FirstName;
            response.LastName = user.LastName;
            return new Response<AuthenticationResponse>(response, $"Authenticated {user.UserName}");
        }

        public async Task<Response<string>> RegisterAsync(RegisterRequest request, string origin)
        {
            //find Visitor
            if (!string.IsNullOrWhiteSpace(request.VisitorCode))
            {
                var visitor = await _GetUser.GetUserByPublicCode(request.VisitorCode);
                if (visitor == null)
                    throw new ApiException($"Visitor By Code '{request.VisitorCode}' not found.");
            }

            //find Price Kind By Country Id
            string currency;
            var tblPriceKind = await _GetInfo.GetPriceKindByCountryId(request.CountryID);
            if (tblPriceKind?.Name != null)
                currency = tblPriceKind.Name;
            else
                currency = "USD";

            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                throw new ApiException($"Username '{request.UserName}' is already taken.");
            }
            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PublicCode = Guid.NewGuid().ToString().Substring(0, 8),
                ApiToken = RandomTokenString(),
                VisitorCode = request.VisitorCode,
                CountryID = request.CountryID,
                Credit = 0,
                Currency = currency,
            };
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());

                    //get verification URI
                    var verificationUri = await SendVerificationEmail(user, origin);

                    //generate Active Account Model
                    var activeAccountModel = new ActiveAccountModel()
                    {
                        FullName = user.FirstName + " " + user.LastName,
                        ActiveLink = verificationUri
                    };

                    //send Active Account Email
                    await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest()
                    {
                        To = user.Email,
                        Body = _ViewRenderService.RenderToStringAsync("_ActiveEmail", activeAccountModel),
                        Subject = "Confirm Registration PocoPanel"
                    });

                    //return response
                    return new Response<string>(user.ApiToken, "ApiToken");
                }
                else
                {
                    string errorText = string.Join(Environment.NewLine, result.Errors.Select(error => error.Description).ToList());
                    throw new ApiException(errorText);
                }
            }
            else
            {
                throw new ApiException($"Email {request.Email } is already registered.");
            }
        }

        private async Task<JwtSecurityToken> GenerateJWToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);

            var roleClaims = new List<Claim>();

            for (int i = 0; i < roles.Count; i++)
            {
                roleClaims.Add(new Claim("roles", roles[i]));
            }

            string ipAddress = IpHelper.GetIpAddress();

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id),
                new Claim("ip", ipAddress),
            }
            .Union(userClaims)
            .Union(roleClaims);

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: _jwtSettings.Issuer,
                audience: _jwtSettings.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
            return jwtSecurityToken;
        }

        private string RandomTokenString()
        {
            using var rngCryptoServiceProvider = new RNGCryptoServiceProvider();
            var randomBytes = new byte[40];
            rngCryptoServiceProvider.GetBytes(randomBytes);
            // convert random bytes to hex string
            return BitConverter.ToString(randomBytes).Replace("-", "");
        }

        private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "account/confirm-email/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(_enpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            //Email Service Call Here
            return verificationUri;
        }

        public async Task<string> ConfirmEmailAsync(string userId, string code, string websiteAddress)
        {
            var user = await _userManager.FindByIdAsync(userId);
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return websiteAddress + "/Home/SignIn/true";
            }
            else
            {
                return websiteAddress + "/Home/SignIn/false";
            }
        }

        private RefreshToken GenerateRefreshToken(string ipAddress)
        {
            return new RefreshToken
            {
                Token = RandomTokenString(),
                Expires = DateTime.UtcNow.AddDays(7),
                Created = DateTime.UtcNow,
                CreatedByIp = ipAddress
            };
        }

        public async Task ForgotPassword(ForgotPasswordRequest model, string origin)
        {
            var account = await _userManager.FindByEmailAsync(model.Email);

            // always return ok response to prevent email enumeration
            if (account == null) return;

            var code = await _userManager.GeneratePasswordResetTokenAsync(account);
            var route = "Auth/ForgotPasswordPage/";
            var _enpointUri = new Uri(string.Concat($"{origin}/", route));

            //generate reset Password Model
            var resetPasswordModel = new ResetPasswordModel()
            {
                Token = code,
                Url = _enpointUri.ToString()
            };

            //send Active Account Email
            await _emailService.SendAsync(new Application.DTOs.Email.EmailRequest()
            {
                From = "infoEmail@pocopanel.ir",
                To = model.Email,
                Body = _ViewRenderService.RenderToStringAsync("_ResetPassword", resetPasswordModel),
                Subject = "Reset Password PocoPanel"
            });
        }

        public async Task<Response<string>> ResetPassword(ResetPasswordRequest model)
        {
            var account = await _userManager.FindByEmailAsync(model.Email);
            if (account == null) throw new ApiException($"No Accounts Registered with {model.Email}.");
            var result = await _userManager.ResetPasswordAsync(account, model.Token, model.Password);
            if (result.Succeeded)
            {
                return new Response<string>(model.Email, message: $"Password Resetted.");
            }
            else
            {
                throw new ApiException($"Error occured while reseting the password.");
            }
        }
    }

}
