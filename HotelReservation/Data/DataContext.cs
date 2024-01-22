using HotelReservation.Areas.Customer.Models;
using HotelReservation.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Data
{

    public class DataContext : IdentityDbContext<AppUser, AppRole, int>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Room> Room { get; set; }
        public DbSet<CustomerInfo> CustomerInfo { get; set; }
        public DbSet<BillingInfo> BillingInfo { get; set; }
        public DbSet<BookingInfo> BookingInfo { get; set; }
        public DbSet<BookingInfoUserRelation> BookingInfoUserRelation { get; set;}


	}

}
