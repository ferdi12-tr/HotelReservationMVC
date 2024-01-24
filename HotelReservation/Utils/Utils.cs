using HotelReservation.Areas.Customer.Models;
using System.Globalization;

namespace HotelReservation.Utils
{
	public class Utils
	{
		private readonly IWebHostEnvironment he;

		public Utils(IWebHostEnvironment he)
		{
			this.he = he;
		}

		public IEnumerable<string[]> UplodaImage(IFormFileCollection? files, string imageLocation)
		{
			

			if (files.Count > 0)
			{
				foreach (var file in files)
				{
					string image = null;
					string fileName = Guid.NewGuid().ToString();
					string imgPath = @"img\"+ imageLocation;
					var upload = Path.Combine(he.WebRootPath, imgPath);
					var ext = Path.GetExtension(file.FileName);
					var ImagePath = Path.Combine(he.WebRootPath, file.Name.TrimStart('\\'));
					if (System.IO.File.Exists(ImagePath))
					{
						System.IO.File.Delete(ImagePath);
					}
					using (var fileStream = new FileStream(Path.Combine(upload, fileName + ext), FileMode.Create))
					{
						file.CopyTo(fileStream);
					}
					image = Path.Combine(imgPath, fileName + ext);
					yield return new string[] { image , file.Name};
				}
			}
			yield break;
		}

		public CustomerInfo FillCustomerInfo(BookModelView bookingModel)
		{
			return new CustomerInfo
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
			
		}

		public BillingInfo FillBillingInfo(BookModelView bookingModel)
		{
			return new BillingInfo
			{
				BillingFirstName = bookingModel.BillingFirstName,
				BillingLastName = bookingModel.BillingLastName,	
				UserName = bookingModel.UserName,
				BillingAddressLine1 = bookingModel.BillingAddressLine1,
				BillingAddressLine2 = bookingModel.BillingAddressLine2,
				BillingCity = bookingModel.BillingCity,
				BillingCountry = bookingModel.BillingCountry,
				BillingState = bookingModel.BillingState,
				BillingZipCode = bookingModel.BillingZipCode,
			};
		}

		public BookingInfo FillBookingInfo(BookModelView bookingModel, int customerInfoId, int billingInfoId)
		{
			if (!DateTime.TryParseExact(bookingModel.CheckInDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newCheckInDate) ||
				!DateTime.TryParseExact(bookingModel.CheckInDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newCheckOutDate))
			{
				throw new ArgumentException("Invalid date format. Please use the format MM/dd/yyyy.");
			}

			return new BookingInfo
			{
				TransactionId = bookingModel.TransactionId,
				IsPaid = false,
				TotalPrice = bookingModel.TotalPrice,
				CheckInDate = newCheckInDate,
				CheckOutDate = newCheckOutDate,
				RoomId = bookingModel.SelectedRoomId,
				CustomerInfoId = customerInfoId,
				BillingInfoId = billingInfoId	
			};
		}
	
		public double CalculateTotalBookingPrice(string checkInDate, string checkOutDate, double pricePerHour)
		{
            if (!DateTime.TryParseExact(checkInDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newCheckInDate) ||
				!DateTime.TryParseExact(checkOutDate, "MM/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime newCheckOutDate))
            {
                throw new ArgumentException("Invalid date format. Please use the format MM/dd/yyyy.");
            }

   //         string[] checkInList = checkInDate.Split('/');
			//string[] checkOutList = checkOutDate.Split("/");
			//var newCheckInDate = new DateTime(Convert.ToInt32(checkInList[2]), Convert.ToInt32(checkInList[1]), Convert.ToInt32(checkInList[0]));
			//var newCheckOutDate = new DateTime(Convert.ToInt32(checkOutList[2]), Convert.ToInt32(checkOutList[1]), Convert.ToInt32(checkOutList[0]));
			TimeSpan timeSpan = newCheckOutDate - newCheckInDate;
            return timeSpan.TotalHours * pricePerHour;
		}
	}
}
