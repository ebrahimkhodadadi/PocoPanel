using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Account
{
    public class ResetPasswordModel
    {
        public string Token { get; set; }
        public string Url { get; set; }
    }
}
