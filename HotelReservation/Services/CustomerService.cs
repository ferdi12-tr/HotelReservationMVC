using HotelReservation.Areas.Customer.Models;
using HotelReservation.Data;
using HotelReservation.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HotelReservation.Services
{
	public class CustomerService : ICustomerService
	{
		private readonly DataContext db;

		public CustomerService(DataContext _db)
		{
			db = _db;
		}

		#region CustomerInfo
		public async Task<int> AddCustomerInfoAsync(CustomerInfo customerInfo)
		{
			try
			{
				var result = db.CustomerInfo.Add(customerInfo);
				await db.SaveChangesAsync();
				return result.Entity.Id;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<IEnumerable<CustomerInfo>> GetAllCustomerInfoAsync()
		{
			try
			{
				var customerInfos = await db.CustomerInfo.ToListAsync();
				return customerInfos;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<CustomerInfo> GetCustomerInfoByIdAsync(int id)
		{
			try
			{
				var customerInfo = await db.CustomerInfo.FindAsync(id);
				return customerInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public Task<CustomerInfo> GetCustomerInfoByFirstNameLastName(string firstName, string lastName)
		{
			try
			{
				var customerInfo = db.CustomerInfo
									.FirstOrDefaultAsync(x =>
									x.FirstName.Equals(firstName) &&
									x.LastName.Equals(lastName));
				return customerInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<CustomerInfo> GetCustomerInfoByUserNameAsync(string userName)
		{
			try
			{
				var customerInfo = await db.CustomerInfo.FirstOrDefaultAsync(x => x.UserName == userName);
				return customerInfo;

			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<int> UpdateCustomerInfoAsync(CustomerInfo newCustomerInfo)
		{
			try
			{
				var result = db.CustomerInfo.Update(newCustomerInfo);
				await db.SaveChangesAsync();
				return result.Entity.Id;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
		#endregion

		#region BillingInfo

		public async Task<int> AddBillingInfoAsync(BillingInfo billingInfo)
		{
			try
			{
				var result = db.BillingInfo.Add(billingInfo);
				await db.SaveChangesAsync();
				return result.Entity.Id;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<int> UpdateBillingInfoAsync(BillingInfo newBillingInfo)
		{
			try
			{
				var result = db.BillingInfo.Update(newBillingInfo);
				await db.SaveChangesAsync();
				return result.Entity.Id;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BillingInfo> GetBillingInfoByIdAsync(int id)
		{
			try
			{
				var billingInfo = await db.BillingInfo.FindAsync(id);
				return billingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BillingInfo> GetBillingInfoByUserNameAsync(string userName)
		{
			try
			{
				var billingInfo = await db.BillingInfo.FirstOrDefaultAsync(x => x.UserName.Equals(userName));	
				return billingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		public async Task<BillingInfo> GetBillingInfoByFirstNameLastNameAsync(string firstName, string lastName)
		{
			try
			{
				var billingInfo = await db.BillingInfo
					.FirstOrDefaultAsync(x =>
					x.BillingFirstName.Equals(firstName) &&
					x.BillingLastName.Equals(lastName)
				);
				return billingInfo;
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}

		#endregion
	}
}
