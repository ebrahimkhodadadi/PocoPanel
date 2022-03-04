using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace PocoPanel.Application.DTOs.Products
{
    public class GetProductDetailViewModel
    {
        public int Id { get; set; }
        public bool IsDelete { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public double? Decending { get; set; }
        public int? QualityId { get; set; }
        public int? ProductKind { get; set; }
        public int? ProductParentKind { get; set; }

        public IEnumerable<SelectListItem> tblQuality { get; set; }
        public IEnumerable<SelectListItem> tblProductKindParent { get; set; }
        public IEnumerable<ProductKindChild> tblProductKindChild { get; set; }
    }

    public class ProductKindChild
    {
        public int Value { get; set; }
        public string Text { get; set; }
        public int? Parent { get; set; }
    }
}
