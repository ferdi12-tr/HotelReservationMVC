
using HotelReservation.Models;

namespace HotelReservation.Areas.Customer.Models
{
	public class CustomerInfo
	{
        public int Id { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
        public string? UserName { get; set; }
        public string? AddressLine1 { get; set; }
		public string? AddressLine2 { get; set; }
		public string? City { get; set; }
		public string? ZipCode { get; set; }
		public string? Country { get; set; }
		public string? State { get; set; }
        public List<BookingInfo>? BookingInfos { get; set; }
	}
}
