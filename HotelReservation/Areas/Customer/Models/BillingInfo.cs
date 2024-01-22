using HotelReservation.Models;

namespace HotelReservation.Areas.Customer.Models
{
	public class BillingInfo
	{
        public int Id { get; set; }
        public string? BillingFirstName { get; set; }
		public string? BillingLastName { get; set; }
        public string? UserName { get; set; }
        public string? BillingAddressLine1 { get; set; }
		public string? BillingAddressLine2 { get; set; }
		public string? BillingCity { get; set; }
		public string? BillingZipCode { get; set; }
		public string? BillingState { get; set; }
		public string? BillingCountry { get; set; }
		public List<BookingInfo>? BookingInfos { get; set; }
	}
}
