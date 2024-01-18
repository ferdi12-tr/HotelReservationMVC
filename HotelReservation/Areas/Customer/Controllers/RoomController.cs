using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ILogger logger;

        public RoomController(IRoomService _roomService, ILogger<RoomController> _logger)
        {
            roomService = _roomService;
            logger = _logger;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var roomList = await roomService.GetAllRoomsAsync();
                return View(roomList);
            }
            catch (Exception e)
            {
                logger.LogError($"RoomController ----- Index ----- {e.Message}");
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult RoomDetails(int roomId) 
        { 
            return View(roomId);
        }
    }
}
