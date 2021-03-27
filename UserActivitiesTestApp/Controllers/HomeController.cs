using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using UserActivitiesTestApp.Models;

namespace UserActivitiesTestApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //[Route("/Account/Login")]
        //[Route("/")]
        //public IActionResult Login()
        //{
        //    return LocalRedirect("/Identity/Account/Login");
        //}

        ////[Route("/Account/Login")]
        //[Route("/")]
        //public IActionResult Test()
        //{
        //    return RedirectToRoute("default",
        //    new { controller = "Home", action = "Privacy" });
        //}
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
