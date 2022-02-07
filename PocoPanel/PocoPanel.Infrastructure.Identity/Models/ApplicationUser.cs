using Microsoft.AspNetCore.Identity;
using PocoPanel.Application.DTOs.Account;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Infrastructure.Identity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
        [StringLength(10)]
        public string PublicCode { get; set; }

        [StringLength(10)]
        public string VisitorCode { get; set; }

        [StringLength(100)]
        public string ApiToken { get; set; }

        public decimal Credit { get; set; } = 0;

        public int CountryID { get; set; }

        public string Currency { get; set; }

        public List<RefreshToken> RefreshTokens { get; set; }

        public bool OwnsToken(string token)
        {
            return this.RefreshTokens?.Find(x => x.Token == token) != null;
        }
    }
}
