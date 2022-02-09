using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public decimal TotallPrice { get; set; }
        public byte Status { get; set; }
    }
}
