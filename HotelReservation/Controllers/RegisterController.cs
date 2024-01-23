using HotelReservation.DTOs.AppUserDTOs;
using HotelReservation.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;

namespace HotelReservation.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> userManager; // this manager comes from Identity Packages
        private readonly Random random; 
        public RegisterController(UserManager<AppUser> _userManager)
        {
            userManager = _userManager;
            random = new Random();
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
                    EmailConfirmCode = random.Next(100000,1000000)
                };

                var result = await userManager.CreateAsync(user, appUserRegisterDTO.Password);
                await userManager.AddToRoleAsync(user, "Customer"); // default register with customer role

                if (result.Succeeded)
                {
                    MimeMessage mimeMessage = new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Hotel Alpha", "ferdikoca.41@gmail.com");
                    MailboxAddress mailboxAddressTo = new MailboxAddress("User", user.Email);

                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddressTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Your Email Comfirmation Code: " + user.EmailConfirmCode;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();
                    mimeMessage.Subject = "Hotel Alpha Email Comfirmation";

                    SmtpClient client = new SmtpClient();
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("ferdikoca.41@gmail.com", "gaov thyo gxwp zlfr");
                    client.Send(mimeMessage);
                    client.Disconnect(true);

                    return RedirectToAction("Index", "ConfirmMail", new { userEmail = user.Email });
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
