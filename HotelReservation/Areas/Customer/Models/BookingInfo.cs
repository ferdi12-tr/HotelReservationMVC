using HotelReservation.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace HotelReservation.Areas.Customer.Models
{
	public class BookingInfo
	{
        public int Id { get; set; }
		public string? TransactionId { get; set; }
		public bool? IsPaid { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int CustomerInfoId { get; set; }
        public CustomerInfo? CustomerInfo { get; set; }
        public int BillingInfoId { get; set; }
        public BillingInfo? BillingInfo { get; set; }
	}
}
