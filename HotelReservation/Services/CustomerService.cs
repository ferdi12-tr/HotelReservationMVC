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

		public async Task AddCustomerInfoAsync(CustomerInfo customerInfo)
		{
			try
			{
				db.CustomerInfo.Add(customerInfo);
				await db.SaveChangesAsync();
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

		public async Task UpdateCustomerInfoAsync(CustomerInfo newCustomerInfo)
		{
			try
			{
				db.CustomerInfo.Update(newCustomerInfo);
				await db.SaveChangesAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}
		}
	}
}
