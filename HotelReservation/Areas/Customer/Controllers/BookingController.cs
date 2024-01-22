using HotelReservation.Areas.Customer.Models;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelReservation.Models;

namespace HotelReservation.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IRoomService roomService;
        private readonly ICustomerService customerService;
        private readonly ILogger logger;

        public BookingController(IRoomService roomService, ILogger<BookingController> logger, ICustomerService customerService)
        {
            this.roomService = roomService;
            this.logger = logger;
            this.customerService = customerService;
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

        [HttpPost]
        public async Task<IActionResult> ConfirmBooking(BookModelView bookingModel)
        {
            try
            {
                var customerInfo = new CustomerInfo
                {
                    FirstName = bookingModel.FirstName,
                    LastName = bookingModel.LastName,
                    UserName = bookingModel.UserName,
                    AddressLine1 = bookingModel.AddressLine1,
                    AddressLine2 = bookingModel.AddressLine2,
                    City = bookingModel.City,
                    ZipCode = bookingModel.ZipCode,
                    Country = bookingModel.Country,
                    State = bookingModel.State
                };
                
                var result = await customerService.GetCustomerInfoByUserNameAsync(customerInfo.UserName);
                if (result == null)
                {
                    await customerService.AddCustomerInfoAsync(customerInfo);
                }
                else
                {
					await customerService.UpdateCustomerInfoAsync(customerInfo);
				}

				return RedirectToAction("Payment", bookingModel);
			}
            catch (Exception e)
            {
				logger.LogError($"BookingController ----- ConfirmBooking ----- {e.Message}");
			}
            return RedirectToAction("ErrorPage", "Home");
        }

        public async Task<IActionResult> Payment(BookModelView bookingModel)
        {
			var selectedRoom = await roomService.GetRoomByIdAsync(bookingModel.SelectedRoomId);

			Options options = new Options();
            options.ApiKey = "sandbox-IggZcAiOwMQcRK8Hab6XjtntIPvQknif";
            options.SecretKey = "sandbox-n1SHplPi9t0FnDK2kIgGERQnSUQtBkkx";
			options.BaseUrl = "https://sandbox-api.iyzipay.com";

			CreateCheckoutFormInitializeRequest request = new CreateCheckoutFormInitializeRequest();
			request.Locale = Locale.TR.ToString();
			request.ConversationId = "123456789";
			request.Price = selectedRoom.PricePerHour.ToString();
            request.PaidPrice = selectedRoom.PricePerHour.ToString();
            request.Currency = Currency.TRY.ToString();
			request.BasketId = "B67832";
			request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
			request.CallbackUrl = "https://localhost:7140/Booking/PaymentCallback?Area=Customer"; /// Geri Dönüş Urlsi


			Buyer buyer = new Buyer();
			buyer.Id = "1";
			buyer.Name = bookingModel.FirstName;
			buyer.Surname = bookingModel.LastName;
			buyer.GsmNumber = "-";
			buyer.Email = "email@email.com";
			buyer.IdentityNumber = "1234565789";
			buyer.LastLoginDate = "2015-09-04 11:40:00";
			buyer.RegistrationDate = "2013-03-12 13:11:00";
			buyer.RegistrationAddress = "İzmir";
			buyer.Ip = "91.93.129.194";
			buyer.City = bookingModel.City;
			buyer.Country = bookingModel.Country;
			buyer.ZipCode = bookingModel.ZipCode;
			request.Buyer = buyer;

			Address shippingAddress = new Address();
			shippingAddress.ContactName = bookingModel.FirstName + " " + bookingModel.LastName;
			shippingAddress.City = bookingModel.City;
			shippingAddress.Country = bookingModel.Country;
			shippingAddress.Description = "-";
			shippingAddress.ZipCode = bookingModel.ZipCode;
			request.ShippingAddress = shippingAddress;

			Address billingAddress = new Address();
			billingAddress.ContactName = bookingModel.BillingFirstName + " " + bookingModel.BillingLastName;
			billingAddress.City = bookingModel.City;
			billingAddress.Country = bookingModel.Country;
			billingAddress.Description = "-";
			billingAddress.ZipCode = bookingModel.ZipCode;
			request.BillingAddress = billingAddress;

			List<BasketItem> basketItems = new List<BasketItem>();
			BasketItem basketItem = new BasketItem();
            basketItem.Id = selectedRoom.Id.ToString();
            basketItem.Name = selectedRoom.RoomName;
            basketItem.Category1 = selectedRoom.Tag;
            basketItem.Price = selectedRoom.PricePerHour.ToString();
            basketItem.ItemType = BasketItemType.PHYSICAL.ToString();
            basketItems.Add(basketItem);

            request.BasketItems = basketItems;
            CheckoutFormInitialize checkoutFormInitialize = CheckoutFormInitialize.Create(request, options);
			ViewBag.pay = checkoutFormInitialize.CheckoutFormContent;
            return View();
        }

        public IActionResult PaymentCallback()
        {
            return View();
        }
    }
}
