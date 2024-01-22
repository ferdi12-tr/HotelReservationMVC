using HotelReservation.Areas.Customer.Models;

namespace HotelReservation.Services.Interfaces
{
	public interface ICustomerService
	{
		#region CustomerInfo

		public Task AddCustomerInfoAsync(CustomerInfo customerInfo);
		public Task<CustomerInfo> GetCustomerInfoByIdAsync(int id);
		public Task<CustomerInfo> GetCustomerInfoByUserNameAsync(string userName);
		public Task<CustomerInfo> GetCustomerInfoByFirstNameLastName(string firstName, string lastName);
		public Task<IEnumerable<CustomerInfo>> GetAllCustomerInfoAsync();
		public Task UpdateCustomerInfoAsync(CustomerInfo newCustomerInfo);

		#endregion

		#region BillingInfo
		public Task AddBillingInfoAsync(BillingInfo billingInfo);	
		public Task UpdateBillingInfoAsync(BillingInfo newBillingInfo);
		public Task<BillingInfo> GetBillingInfoByIdAsync(int id);
		public Task<BillingInfo> GetBillingInfoByUserNameAsync(string userName);
		public Task<BillingInfo> GetBillingInfoByFirstNameLastNameAsync(string firstName, string lastName);	
		#endregion
	}
}
