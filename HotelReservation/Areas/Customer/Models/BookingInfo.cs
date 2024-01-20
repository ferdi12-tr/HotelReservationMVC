using HotelReservation.Models;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;
using System.Security.Principal;

namespace HotelReservation.Areas.Customer.Models
{
	public class BookingInfo
	{
        public int Id { get; set; }
		public DateTime CheckInDate { get; set; }
		public DateTime CheckOutDate { get; set; }
		public int RoomId { get; set; }
        public Room? Room { get; set; }
        public int PaymentInfoId { get; set; }
        public PaymentInfo? PaymentInfo { get; set; }
        public int BillingInfoId { get; set; }
        public BillingInfo? BillingInfo { get; set; }
		public List<BookingInfoUserRelation>? BookingInfoUserRelations { get; set; }
	}
}
