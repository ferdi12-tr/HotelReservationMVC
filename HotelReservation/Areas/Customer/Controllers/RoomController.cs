using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RoomDetails(int roomId) 
        { 
            return View(roomId);
        }
    }
}
