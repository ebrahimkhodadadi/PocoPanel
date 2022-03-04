using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Product
{
    public class ListProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public int? ProviderProductID { get; set; }
        public decimal ProviderPrice { get; set; }
    }
}
