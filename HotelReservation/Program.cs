using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.Services;
using HotelReservation.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //Database
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connectionString));

            //Custom Services
            builder.Services.AddTransient<IRoomService, RoomService>();
            builder.Services.AddTransient<ICustomerService, CustomerService>();
            builder.Services.AddTransient<IBookingService, BookingService>();
            builder.Services.AddScoped<Utils.Utils, Utils.Utils>();

            //Identity
            builder.Services.AddIdentity<AppUser, AppRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<DataContext>();

			builder.Services.ConfigureApplicationCookie(options =>
			{
				options.LoginPath = "/Login/Index";
				//options.LogoutPath = "/Identity/Account/Logout";
				//options.AccessDeniedPath = $"/Identity/Account/AccessDenied";

			});

			// Add services to the container.
			builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapAreaControllerRoute(
                name: "Customer",
                areaName: "Customer",
                pattern: "{controller=Room}/{action=Index}/{id?}");

			app.MapAreaControllerRoute(
				name: "Customer",
				areaName: "Customer",
				pattern: "{controller=Booking}/{action=PaymentCallback}/{id?}");

			app.Run();
        }
    }
}