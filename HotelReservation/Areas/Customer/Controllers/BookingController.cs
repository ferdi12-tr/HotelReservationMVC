using HotelReservation.Areas.Customer.Models;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class BookingController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ILogger logger;

        public BookingController(IRoomService roomService, ILogger<BookingController> logger)
        {
            this.roomService = roomService;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index(BookModelView model) // send filled model from room detail page
        {
            try
            {
                var selectedRoom = await roomService.GetRoomByIdAsync(model.SelectedRoomId);
                model.Room = selectedRoom;
                return View(model);
            }
            catch (Exception e)
            {
                logger.LogError($"BookingController ----- Index ----- {e.Message}");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SelectedRoom(Room selectedRoom) // partial view with room model
        {
            return View(selectedRoom);
        }

        public IActionResult PersonalInfo(BookModelView model) // To display booked room and dates
        {
            return View(model);
        }

        public IActionResult PaymentInfo(BookModelView model)
        {
            return View(model);
        }

        public IActionResult ReviewBook(BookModelView model)
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult ConfirmBooking(BookModelView modelView)
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
