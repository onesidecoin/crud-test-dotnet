using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer
{
    public record CreateCustomerCommand : IRequest<ServiceResponse<CustomerDto>>
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int BankAccountNumber { get; set; }

    }

    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, ServiceResponse<CustomerDto>>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }

        public async Task<ServiceResponse<CustomerDto>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Firstname = request.Firstname,
                Lastname = request.Lastname,
                Email = request.Email,
                DateOfBirth = request.DateOfBirth,
                PhoneNumber = request.PhoneNumber,
                BankAccountNumber = request.BankAccountNumber,
            };

            // todo : 
            //entity.AddDomainEvent(new TodoItemCreatedEvent(entity));

            var creationResult = await _repo.CreateAsync(entity, cancellationToken);


            if (creationResult.IsSuccessful)
            {
                var dto = _mapper.Map<CustomerDto>(entity);
                return new ServiceResponse<CustomerDto>(dto);
            }
            else
            {
                return new ServiceResponse<CustomerDto>(creationResult.ErrorMessage);
            }
        }
    }
}
