using HotelReservation.Areas.Customer.Models;

namespace HotelReservation.Services.Interfaces
{
	public interface ICustomerService
	{
		public Task AddCustomerInfoAsync(CustomerInfo customerInfo);
		public Task<CustomerInfo> GetCustomerInfoByIdAsync(int id);
		public Task<CustomerInfo> GetCustomerInfoByUserNameAsync(string userName);
        public Task<CustomerInfo> GetCustomerInfoByFirstNameLastName(string firstName, string lastName);
		public Task<IEnumerable<CustomerInfo>> GetAllCustomerInfoAsync();
		public Task UpdateCustomerInfoAsync(CustomerInfo newCustomerInfo);
	}
}
