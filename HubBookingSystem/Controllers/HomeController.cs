using HubBookingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HubBookingSystem.Controllers
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

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Info()
        {
            return View();
        }

        public IActionResult Services()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

     }
}
