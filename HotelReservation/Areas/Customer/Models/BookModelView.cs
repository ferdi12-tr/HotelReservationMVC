namespace HotelReservation.Areas.Customer.Models
{
    public class BookModelView
    {
        public Room? Room { get; set; }
        public int SelectedRoomId { get; set; }
        public string? CheckInDate { get; set; }
        public string? CheckOutDate { get; set; }

        #region PaymentInfo
        public string? PaymentId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
        public string? State { get; set; }
        #endregion

        #region BillingInfo
        public string? BillingFirstName { get; set; }
        public string? BillingLastName { get; set; }
        public string? BillingAddressLine1 { get; set; }
        public string? BillingAddressLine2 { get; set; }
        public string? BillingCity { get; set; }
        public string? BillingZipCode { get; set; }
        public string? BillingState { get; set; }
        public string? BillingCountry { get; set; }
        #endregion

        


    }
}
