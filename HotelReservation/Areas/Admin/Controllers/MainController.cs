using HotelReservation.Areas.Customer.Models;
using HotelReservation.Data;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Tsp;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
	[Authorize(Roles="Admin")]
    public class MainController : Controller
    {
        private readonly IRoomService roomService;
		private readonly ILogger logger;
		private readonly Utils.Utils utils;

		public MainController(
			IRoomService roomService, 
			ILogger<MainController> logger, 
			Utils.Utils utils
		)
        {
            this.roomService = roomService;
            this.utils = utils;
            this.logger = logger;
        }

		[HttpGet]
        public async Task<IActionResult> Index()
        {
            var roomList = await roomService.GetAllRoomsAsync();
            return View(roomList);
        }

        [HttpGet]
        public async Task<IActionResult> UpdateRoom(int roomId)
        {
            var room = await roomService.GetRoomByIdAsync(roomId);
            return View(room);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateRoom(Room updatedRoom)
        {
            try
            {
				if (ModelState.IsValid)
				{
					var files = HttpContext.Request.Form.Files;
					foreach (var imageInfo in utils.UplodaImage(files, "room")) // to find out which file has changed
					{
						if (imageInfo[1] == nameof(updatedRoom.ImgUrl1))
						{
							updatedRoom.ImgUrl1 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(updatedRoom.ImgUrl2))
						{
							updatedRoom.ImgUrl2 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(updatedRoom.ImgUrl3))
						{
							updatedRoom.ImgUrl3 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(updatedRoom.ImgUrl4))
						{
							updatedRoom.ImgUrl4 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(updatedRoom.ImgUrl5))
						{
							updatedRoom.ImgUrl5 = imageInfo[0];
						}
					}
					await roomService.UpdateRoomAsync(updatedRoom);
					return View(updatedRoom);
				}
			}
            catch (Exception e)
            {

				logger.LogError($"MainController ----- UpdateRoom ----- {e.Message}");
			}
			return RedirectToAction("ErrorPage", "Home");
		}

		[HttpGet]
		public async Task<IActionResult> CreateRoom()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> CreateRoom(Room createdRoom) 
		{
			try
			{
				if (ModelState.IsValid)
				{
					var files = HttpContext.Request.Form.Files;
					foreach (var imageInfo in utils.UplodaImage(files, "room")) // to find out which file has changed
					{
						if (imageInfo[1] == nameof(createdRoom.ImgUrl1))
						{
							createdRoom.ImgUrl1 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(createdRoom.ImgUrl2))
						{
							createdRoom.ImgUrl2 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(createdRoom.ImgUrl3))
						{
							createdRoom.ImgUrl3 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(createdRoom.ImgUrl4))
						{
							createdRoom.ImgUrl4 = imageInfo[0];
						}
						else if (imageInfo[1] == nameof(createdRoom.ImgUrl5))
						{
							createdRoom.ImgUrl5 = imageInfo[0];
						}
					}
					await roomService.AddRoomAsync(createdRoom);
				}
				return RedirectToAction("Index", "Main");
			}
			catch (Exception e)
			{
				logger.LogError($"MainController ----- CreateRoom ----- {e.Message}");
			}
			return RedirectToAction("ErrorPage", "Home");
		}

	}
}
