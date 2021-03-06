using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Application.DTOs.Account
{
    public class RegisterRequest
    {
        [Required]
        [MinLength(3, ErrorMessage = "{0} Min Lenght is 3")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "{0} Min Lenght is 3")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required]
        [MinLength(8)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        public string VisitorCode { get; set; }

        public int CountryID { get; set; }
    }
}
