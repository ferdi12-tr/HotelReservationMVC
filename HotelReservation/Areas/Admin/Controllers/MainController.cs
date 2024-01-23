﻿using HotelReservation.Areas.Customer.Models;
using HotelReservation.Data;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Areas.Admin.Controllers
{
    [Area("Admin")]
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
					foreach (var imageInfo in utils.UplodaImage(files)) // to find out which file has changed
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
    }
}
