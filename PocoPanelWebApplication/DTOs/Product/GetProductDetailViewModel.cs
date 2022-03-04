using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Product
{
    public class GetProductDetailViewModel
    {
        public int Id { get; set; }

        public bool IsDelete { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Min { get; set; }

        public int Max { get; set; }

        public double? Decending { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [DisplayName("Quality")]
        public int? QualityId { get; set; }

        [DisplayName("Product Kind")]
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
