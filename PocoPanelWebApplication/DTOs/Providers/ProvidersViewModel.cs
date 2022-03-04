using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.DTOs.Providers
{
    public class ProvidersViewModel
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string Code { get; set; }
        public string DocumentAddress { get; set; }
        public decimal Credit { get; set; }
    }
}
