using HotelReservation.Models;

namespace HotelReservation.Areas.Customer.Models
{
	public class BookingInfoUserRelation
	{
        public int Id { get; set; }
        public int AppUserId { get; set; }
        public AppUser? AppUser { get; set; }
        public int BookingInfoId { get; set; }
        public BookingInfo? BookingInfo { get; set; }
    }
}
