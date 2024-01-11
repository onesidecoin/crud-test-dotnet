using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Shared.Dtos;

namespace Mc2.CrudTest.Presentation.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        public Task<Customer> GetByIdAsync(Guid id);
        public Task<IEnumerable<Customer>> GetByIdsAsync(IEnumerable<Guid> ids);

        public Task<ServiceResponse<Customer>> CreateAsync(Customer customer, CancellationToken? cancellationToken = default);
        public Task<ServiceResponse<Customer>> UpdateAsync(Customer customer, CancellationToken? cancellationToken = default);
        public Task<ServiceResponse<bool>> DeleteAsync(Customer customer, CancellationToken? cancellationToken = default);
        public Task<ServiceResponse<bool>> DeleteAsync(Guid customerId, CancellationToken? cancellationToken = default);
    }
}
