using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PocoPanel.Application.DTOs.Factors
{
    public class CreateFactorCommandViewModel
    {
        public string Description { get; set; }
        [Required]
        public string SocialUserName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int ServiceId { get; set; }

        public string DiscountCode { get; set; }
    }
}
