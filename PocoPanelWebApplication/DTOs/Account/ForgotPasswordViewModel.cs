using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Account
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "{0} is required")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
