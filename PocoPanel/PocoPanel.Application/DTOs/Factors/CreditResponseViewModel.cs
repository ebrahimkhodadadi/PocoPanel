using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Factors
{
    public class CreditResponseViewModel
    {
        public string status { get; set; }
        public decimal balance { get; set; }
        public string currency { get; set; }
    }
}
