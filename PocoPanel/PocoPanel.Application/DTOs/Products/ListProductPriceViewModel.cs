using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Products
{
    public class ListProductPriceViewModel
    {
        public int ProductId { get; set; }
        public decimal Rial { get; set; }
        public decimal USD { get; set; }
    }
}
