using System.Security.Principal;

namespace HotelReservation.Areas.Customer.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string? RoomName { get; set; }
        public string? Description { get; set; }
        public double PricePerHour { get; set; }
        public string? Tag { get; set; }
        public string? Address { get; set; }
        public List<BookingInfo>? BookingInfos { get; set; }

        #region Image
        public string? ImgUrl1 { get; set; }
        public string? ImgUrl2 { get; set; }
        public string? ImgUrl3 { get; set; }
        public string? ImgUrl4 { get; set; }
        public string? ImgUrl5 { get; set; }
        #endregion

        #region Amenities
        public bool HasAirConditioning { get; set; }
        public bool HasBalcony { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasBeachView { get; set; }
        public int Bethroom { get; set; } = 1;
        public bool HasFreeNewspaper { get; set; }
        public bool HasPool { get; set; }
        public bool HasTv { get; set; }
        public bool HasRoomService { get; set; }
        public bool HasBreakfast { get; set; }
        public bool HasFreeWifi { get; set; }
        #endregion

    }
}
