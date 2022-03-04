using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Factors
{
    public class AcceptOrderDetailViewModel
    {
        public int? OrderId { get; set; }
        public int? OrderDetailId { get; set; }
        public string DateTime { get; set; }
        public string Price { get; set; }
    }
}
