using HotelReservation.Areas.Admin.Controllers;
using HotelReservation.Areas.Customer.Models;
using HotelReservation.Models;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace HotelReservation.Areas.Customer.Controllers
{
	[Area("Customer")]
	[Authorize(Roles = "Admin, Customer")]
	public class AccountController : Controller
	{
		private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
		private readonly IBookingService bookingService;
        private readonly ILogger logger;
        private readonly Utils.Utils utils;

        public AccountController(
			UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
			IBookingService bookingService,
            ILogger<AccountController> logger,
            Utils.Utils utils
        )
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
			this.bookingService = bookingService;
			this.logger = logger;
			this.utils = utils;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var user = await  userManager.FindByNameAsync(User.Identity.Name);
			var account = new AccountModelView 
			{ 
				Id = user.Id,
				Name = user.Name,
				Surname = user.Surname,
				ImageUrl = user.ImageUrl,
				UserName = user.UserName,
				Email = user.Email,
				OldPassword=user.PasswordHash
			};
			return View(account);
		}

        public async Task<IActionResult> Index(AccountModelView newAccount)
		{
			try
			{
				var updatedUser = new AppUser();
                if (ModelState.IsValid)
				{
                    var files = HttpContext.Request.Form.Files;
                    foreach (var imageInfo in utils.UplodaImage(files, "avatar"))
					{
						updatedUser.ImageUrl = imageInfo[0];
					}
                }

				updatedUser.Name = newAccount.Name;
				updatedUser.Surname = newAccount.Surname;
				updatedUser.Email = newAccount.Email;
				updatedUser.UserName = newAccount.UserName;
				
                var result1 = await userManager.ChangePasswordAsync(updatedUser, newAccount.OldPassword, newAccount.NewPassword);
				updatedUser.SecurityStamp = Guid.NewGuid().ToString();
                var result2 = await userManager.UpdateAsync(updatedUser);

                await Console.Out.WriteLineAsync("password");
                if (!result1.Succeeded) 
				{
                    foreach (var item in result1.Errors)
                    {
                        await Console.Out.WriteLineAsync(item.Description);
                    }
                }

                await Console.Out.WriteLineAsync("user");
                if (!result2.Succeeded) 
				{
                    foreach (var item in result2.Errors)
                    {
                        await Console.Out.WriteLineAsync(item.Description);
                    }
                }
				await signInManager.RefreshSignInAsync(updatedUser);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                logger.LogError($"MainController ----- UpdateRoom ----- {e.Message}");
            }
            return RedirectToAction("ErrorPage", "Home");
		}

		public async Task<IActionResult> BookingInfos()
		{
			try
			{
                var userName = User.Identity.Name;
                var customer = await userManager.FindByNameAsync(userName);
                var bookDetails = await bookingService.GetBookingInfoByCustomerId(customer.Id);
                return View(bookDetails);
            }
			catch (Exception e)
			{
                logger.LogError($"BookingController ----- ConfirmBooking ----- {e.Message}");
            }
            return RedirectToAction("ErrorPage", "Home");
        }
    }
}
