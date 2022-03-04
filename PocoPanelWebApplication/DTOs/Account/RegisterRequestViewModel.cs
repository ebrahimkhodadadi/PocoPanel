using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Account
{
    public class RegisterRequestViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(6)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [MinLength(8)]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8}$", ErrorMessage = "Password must have Big And Small letter also with numbers and Symbols requirements")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Compare("Password")]
        [Display(Name = "Password Confirmation")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Visitor Code")]
        public string VisitorCode { get; set; }

        [Display(Name = "Country")]
        public int CountryID { get; set; }

    }
}
