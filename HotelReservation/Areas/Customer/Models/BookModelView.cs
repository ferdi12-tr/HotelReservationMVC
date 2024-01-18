namespace HotelReservation.Areas.Customer.Models
{
    public class BookModelView
    {
        public Room? Room { get; set; }
        public int SelectedRoomId { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }

        #region PaymentInfo
        public string? FirstName;
        public string? LastName;
        #endregion
    }
}
