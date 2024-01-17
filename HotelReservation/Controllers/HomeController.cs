using HotelReservation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservation.Controllers
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
        
        public IActionResult DisplayBlogs()
        {
            return View();
        }

        public IActionResult DisplayHotels()
        {
            return View();
        }
    }
}
