using HotelReservation.Areas.Customer.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SelectedRoom(BookModelView model)
        {
            return View(model);
        }
    }
}
