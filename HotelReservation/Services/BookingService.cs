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

		public async Task AddBookingInfoAsyc(BookingInfo bookingInfo, int appUserId)
		{
			try
			{
				var returnedBookinInfo = db.BookingInfo.Add(bookingInfo);
				var addedBookingInfo = returnedBookinInfo.Entity;
				await db.SaveChangesAsync();

				db.BookingInfoUserRelation.Add(new BookingInfoUserRelation
				{
					AppUserId = appUserId,
					BookingInfoId = addedBookingInfo.Id
				});
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
				var relation = await db.BookingInfoUserRelation
					.Where(x => x.AppUserId == customerId)
					.Include(x => x.BookingInfo).FirstOrDefaultAsync();

				return new BookingInfo
				{
					Id = relation.BookingInfoId,
					TransactionId = relation.BookingInfo.TransactionId,
					IsPaid = relation.BookingInfo.IsPaid,
					CheckInDate = relation.BookingInfo.CheckInDate,
					CheckOutDate = relation.BookingInfo.CheckOutDate,
					RoomId = relation.BookingInfo.RoomId,
					Room = relation.BookingInfo.Room,
					CustomerInfoId = relation.BookingInfo.CustomerInfoId,
					CustomerInfo = relation.BookingInfo.CustomerInfo,
					BillingInfoId = relation.BookingInfo.BillingInfoId,
					BillingInfo = relation.BookingInfo.BillingInfo,
				};
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
