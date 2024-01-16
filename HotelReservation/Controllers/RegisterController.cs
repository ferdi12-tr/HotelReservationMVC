using HotelReservation.DTOs.AppUserDTOs;
using HotelReservation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager; // this manager comes from Identity Packages

        public RegisterController(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDTO appUserRegisterDTO)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser() 
                { 
                    UserName = appUserRegisterDTO.UserName,
                    Name = appUserRegisterDTO.Name,
                    Surname = appUserRegisterDTO.Surname,   
                    Email = appUserRegisterDTO.Email,
                };

                var result = await userManager.CreateAsync(user, appUserRegisterDTO.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
