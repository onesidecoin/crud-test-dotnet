using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.EditCustomer
{
    public class EditCustomerCommand : IRequest<ServiceResponse<CustomerDto>>
    {
        public Guid Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BankAccountNumber { get; set; }
    }

    public class EditCustomerCommandHandler : IRequestHandler<EditCustomerCommand, ServiceResponse<CustomerDto>>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public EditCustomerCommandHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }

        public async Task<ServiceResponse<CustomerDto>> Handle(EditCustomerCommand request, CancellationToken cancellationToken)
        {

            var customer = await _repo.GetByIdAsync(request.Id);

            if (customer == null)
                return new ServiceResponse<CustomerDto>("didnt find data for given id");


            customer.Firstname = request.Firstname;
            customer.Lastname  = request.Lastname;
            customer.PhoneNumber = request.PhoneNumber;
            customer.DateOfBirth = request.DateOfBirth;
            customer.BankAccountNumber = request.BankAccountNumber;
            customer.Email = request.Email;

            // todo : 
            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            var updateResult = await _repo.UpdateAsync(customer, cancellationToken);

            if (updateResult.IsSuccessful)
            {
                var dto = _mapper.Map<CustomerDto>(customer);
                return new ServiceResponse<CustomerDto>(dto);
            }
            else
            {
                return new ServiceResponse<CustomerDto>(updateResult.ErrorMessage);
            }
        }
    }

}
