using HotelReservation.Models;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HotelReservation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger, IRoomService roomService)
        {
            this.logger = logger;
            this.roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var roomList = await roomService.GetAllRoomsAsync();
                return View(roomList.Take(3).ToList());
            }
            catch (Exception e)
            {
                logger.LogError($"BookingController ----- ConfirmBooking ----- {e.Message}");
            }
            return RedirectToAction("ErrorPage", "Home");
        }

        public IActionResult DisplayRooms()
        {
            return View();
        }
		public IActionResult ErrorPage()
		{
			return View();
		}
	}
}
