using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PocoPanelWebApplication.DTOs.Account;
using PocoPanelWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PocoPanelWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [Route("Home/SignIn/{name}")]
        public IActionResult SignIn(string name)
        {
            if (name == "true")
                ViewBag.canSign = true;
            else if (name == "false")
                ViewBag.canSign = false;
            else
                return NotFound();

            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
    }
}
