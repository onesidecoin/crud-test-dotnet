using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.DeleteCustomer
{
    public record DeleteCustomerCommand : IRequest<ServiceResponse<bool>>
    {
        public Guid CustomerId { get; set; }
    }

    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, ServiceResponse<bool>>
    {
        private readonly ICustomerRepository _repo;

        public DeleteCustomerCommandHandler(ICustomerRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {

            var result = await _repo.DeleteAsync(request.CustomerId, cancellationToken);

            // todo : 
            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            return result;
        }
    }
}
