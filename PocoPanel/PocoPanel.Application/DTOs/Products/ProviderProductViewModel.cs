using System;
using System.Collections.Generic;
using System.Text;

namespace PocoPanel.Application.DTOs.Products
{
    public class ProviderProductViewModel
    {
        public int service { get; set; }
        public string name { get; set; }
        public string category { get; set; }
        public double rate { get; set; }
        public int min { get; set; }
        public int max { get; set; }
        public string type { get; set; }
        public string desc { get; set; }
        public int dripfeed { get; set; }
    }
}
