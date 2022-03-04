using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Product
{
    public class ListProductPriceViewModel
    {
        public int ProductId { get; set; }
        public decimal Rial { get; set; }
        public decimal USD { get; set; }
    }
}
