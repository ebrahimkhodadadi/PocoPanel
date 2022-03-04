using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Products
{
    public class GetAllProductsByProductKindViewModel
    {
        public int id { get; set; }
        public string price { get; set; }
        public int Count { get; set; }
        public double Decending { get; set; }
        public string Description { get; set; }
        public string themeColor { get; set; }
        public string bgImgUrl { get; set; }
        public string Title { get; set; }
        public string ParentTitle { get; set; }
        public string ChildTitle { get; set; }
    }
}
