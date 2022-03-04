using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Provider { get; set; }
        public int? ProviderProductID { get; set; }
        public decimal ProviderPrice { get; set; }
    }
}
