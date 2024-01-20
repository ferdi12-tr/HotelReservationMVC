using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
	public class LoginController : Controller
	{
		private readonly SignInManager<AppUser> signInManager;
		private readonly UserManager<AppUser> userManager;

		public LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager)
		{
			signInManager = _signInManager;
			userManager = _userManager;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			var result = await signInManager.PasswordSignInAsync(loginViewModel.UserName, loginViewModel.Password, false, true);
			if (result.Succeeded)
			{
				var user = await userManager.FindByNameAsync(loginViewModel.UserName);
				if (user.EmailConfirmed == true)
				{
					return RedirectToAction("Index", "Home");
				}
			}
			return View();
		}

		public IActionResult LogOut()
		{
			signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}
