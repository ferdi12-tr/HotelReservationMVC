using HotelReservation.Areas.Customer.Models;
using HotelReservation.Data;
using HotelReservation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services
{
	public class BookingService : IBookingService
	{
		private readonly DataContext db;

		public BookingService(DataContext _db)
		{
			db = _db;
		}

		public async Task AddBookingInfoAsyc(BookingInfo bookingInfo)
		{
			try
			{
				var returnedBookinInfo = db.BookingInfo.Add(bookingInfo);
				await db.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BookingInfo> GetBookingInfoByIdAsync(int id)
		{
			try
			{
				var bookingInfo = await db.BookingInfo.FindAsync(id);
				return bookingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BookingInfo> GetBookingInfoByTransactionId(string transactionId)
		{
			try
			{
				var bookingInfo = await db.BookingInfo.FirstOrDefaultAsync(x => transactionId.Equals(x.TransactionId));
				return bookingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BookingInfo> GetBookingInfoByCustomerId(int customerId)
		{
			try
			{
				var bookingInfo = await db.BookingInfo
					.Where(x => x.AppUserId == customerId)
					.FirstOrDefaultAsync();

				return bookingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task UpdateBookingInfoAsync(BookingInfo NewBookingInfo)
		{
			try
			{
				db.BookingInfo.Update(NewBookingInfo);
				await db.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
