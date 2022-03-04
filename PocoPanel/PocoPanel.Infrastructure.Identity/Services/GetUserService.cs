using System.Runtime.Intrinsics.X86;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PocoPanel.Application.DTOs.Account;
using PocoPanel.Application.Interfaces;
using PocoPanel.Infrastructure.Identity.Contexts;
using PocoPanel.Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using PocoPanel.Infrastructure.Identity.Models;

namespace PocoPanel.Infrastructure.Identity.Services
{
    public class GetUserService : IGetUser
    {
        private readonly IdentityContext _IdentityContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IConvert _IConvert;
        private readonly IMemoryCache _cache;

        public GetUserService(IdentityContext IdentityContext, IMemoryCache cache, IConvert iConvert, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _IdentityContext = IdentityContext;
            _cache = cache;
            _IConvert = iConvert;
        }

        public async Task<string> GetUserID(string ApiToken)
        {
            string UserID;
            
            //check if User is in cash
            if (!_cache.TryGetValue(ApiToken, out UserID))
            {
                //find User
                var user = await _IdentityContext.Users.FirstOrDefaultAsync(User => User.ApiToken == ApiToken);
                if (user == null)
                    return null;
                if (!user.EmailConfirmed)
                    throw new ApiException($"Please Confirm Your Account by visiting your Email");

                // Save data in cache and set the relative expiration time to one day
                _cache.Set(ApiToken, user.Id, TimeSpan.FromDays(1));
                UserID = user.Id;
            }
            return UserID;
        }

        [ResponseCache(Duration = 60)]
        public async Task<GetUserProfile> GetUserByToken(string ApiToken)
        {
            var user = await _IdentityContext.Users.FirstOrDefaultAsync(User => User.ApiToken == ApiToken);
            if (user == null)
                return null;
            if (!user.EmailConfirmed)
                throw new ApiException($"Please Confirm Your Account by visiting your Email");

            return (new GetUserProfile()
            {
                UserID = user.Id,
                Email = user.Email,
                PublicCode = user.PublicCode,
                Credit = _IConvert.RoundNumber(user.Credit),
                Currency = user.Currency
            });
        }

        public async Task<GetUserProfile> GetUserByPublicCode(string publicCode)
        {
            var user = await _IdentityContext.Users.FirstOrDefaultAsync(User => User.PublicCode == publicCode);
            if (user == null)
                return null;
            if (!user.EmailConfirmed)
                throw new ApiException($"Please Confirm Your Account by visiting your Email");

            return (new GetUserProfile()
            {
                UserID = user.Id,
                Email = user.Email,
                PublicCode = user.PublicCode,
                Credit = _IConvert.RoundNumber(user.Credit),
                Currency = user.Currency
            });
        }
    }
}