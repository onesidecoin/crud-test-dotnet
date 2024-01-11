using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Mc2.CrudTest.Presentation.Infrastructure.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly AppDbContext _appDbContext;

		public CustomerRepository(AppDbContext appDbContext)
		{
			_appDbContext=appDbContext;
		}

		public async Task<ServiceResponse<Customer>> CreateAsync(Customer customer, CancellationToken? cancellationToken = null)
		{
			var tracker = _appDbContext.Customers.Add(customer);
			var changes = await _appDbContext.SaveChangesAsync();

			if (changes > 0)
				return new ServiceResponse<Customer>(tracker.Entity);

			return new ServiceResponse<Customer>("insertion failed");
		}

		public async Task<ServiceResponse<bool>> DeleteAsync(Customer customer, CancellationToken? cancellationToken = null)
		{
			_appDbContext.Customers.Remove(customer);
			await _appDbContext.SaveChangesAsync();

			return new ServiceResponse<bool>();
		}

		public async Task<ServiceResponse<bool>> DeleteAsync(Guid customerId, CancellationToken? cancellationToken = null)
		{
			var customer = await _appDbContext.Customers.FirstOrDefaultAsync(s => s.Id == customerId);

			if (customer == null)
				return new ServiceResponse<bool>(true);

			_appDbContext.Customers.Remove(customer);
			await _appDbContext.SaveChangesAsync();

			return new ServiceResponse<bool>(true);
		}

		public async Task<IEnumerable<Customer>> GetAll()
		{
			return await _appDbContext.Customers.ToListAsync();
		}

		public async Task<Customer> GetByIdAsync(Guid id)
		{
			return await _appDbContext.Customers.FindAsync(id);
		}

		public async Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<Guid> ids)
		{
			return await _appDbContext.Customers.Where(s => ids.Contains(s.Id)).ToListAsync();
		}

		public async Task<ServiceResponse<Customer>> UpdateAsync(Customer customer, CancellationToken? cancellationToken = null)
		{
			var tracker = _appDbContext.Customers.Update(customer);
			var changes = await _appDbContext.SaveChangesAsync();

			if (changes > 0)
				return new ServiceResponse<Customer>(tracker.Entity);

			return new ServiceResponse<Customer>("update failed");
		}
	}
}
