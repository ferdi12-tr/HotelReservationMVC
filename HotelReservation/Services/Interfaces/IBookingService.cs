using HotelReservation.Areas.Customer.Models;

namespace HotelReservation.Services.Interfaces
{
	public interface IBookingService
	{
		public Task AddBookingInfoAsyc(BookingInfo bookingInfo);
		public Task UpdateBookingInfoAsync(BookingInfo NewBookingInfo);
		public Task<BookingInfo> GetBookingInfoByIdAsync(int id);
		public Task<BookingInfo> GetBookingInfoByTransactionId(string transactionId);
		public Task<IEnumerable<BookingInfo>> GetBookingInfoByCustomerId(int customerId);
	}
}
