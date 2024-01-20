using HotelReservation.Areas.Customer.Models;
using Microsoft.AspNetCore.Identity;

namespace HotelReservation.Models
{
    public class AppUser : IdentityUser<int>
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        public int EmailConfirmCode { get; set; }
        public List<BookingInfoUserRelation>? BookingInfoUserRelations { get; set; }
    }
}
