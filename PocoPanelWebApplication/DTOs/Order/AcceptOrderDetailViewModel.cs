using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Order
{
    public class AcceptOrderDetailViewModel
    {
        public int OrderId { get; set; }
        public int OrderDetailId { get; set; }
        public string DateTime { get; set; }
        public string Price { get; set; }
    }
}
