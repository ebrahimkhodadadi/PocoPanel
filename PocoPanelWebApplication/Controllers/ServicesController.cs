using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.Controllers
{
    public class ServicesController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("NotFound");
        }
    }
}
