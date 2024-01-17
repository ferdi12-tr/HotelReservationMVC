using System.Reflection.Metadata.Ecma335;

namespace HotelReservation.Models
{
	public class ConfirmMailViewModel
	{
        public int Id { get; set; }
        public string? RegisteredEmail { get; set; }
        public string? ConfirmCode { get; set; }
    }
}
