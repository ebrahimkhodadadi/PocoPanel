using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.Application.DTOs.Account
{
    public class GetUserProfile
    {
        public string Email { get; set; }
        public string PublicCode { get; set; }
        public decimal Credit { get; set; }
        public string Currency { get; set; }
    }
}