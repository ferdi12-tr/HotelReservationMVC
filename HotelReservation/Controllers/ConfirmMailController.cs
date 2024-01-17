using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
	public class ConfirmMailController : Controller
	{
		private readonly UserManager<AppUser> userManager;

		public ConfirmMailController(UserManager<AppUser> _userManager)
		{
			userManager = _userManager;
		}

		[HttpGet]
		public IActionResult Index(string userEmail) // this user email comes from register index
		{
			var viewModel = new ConfirmMailViewModel
			{
				RegisteredEmail = userEmail
			};
			return View(viewModel);
		}


		[HttpPost]
		public async Task<IActionResult> Index(ConfirmMailViewModel confirmMailViewModel)
		{
			var user = await userManager.FindByEmailAsync(confirmMailViewModel.RegisteredEmail);
			if (user.EmailConfirmCode.ToString().Equals(confirmMailViewModel.ConfirmCode))
			{
				user.EmailConfirmed = true;	
				await userManager.UpdateAsync(user);
				return RedirectToAction("Index", "Home");
			}
			return View();
		}
	}
}
