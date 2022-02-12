using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PocoPanel.Application.DTOs.Account
{
    public class GetUserProfile
    {
        [JsonIgnore]
        public string UserID { get; set;}

        public string Email { get; set; }
        public string PublicCode { get; set; }
        public decimal Credit { get; set; }
        public string Currency { get; set; }
    }
}