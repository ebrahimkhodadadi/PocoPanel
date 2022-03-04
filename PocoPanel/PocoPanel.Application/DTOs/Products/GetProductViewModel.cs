using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanel.Application.DTOs.Products
{
    public class GetProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double? Decending { get; set; }
        public decimal? Price { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public string MainCategory { get; set; }
        public string Category { get; set; }
        public string Quality { get; set; }
    }
}