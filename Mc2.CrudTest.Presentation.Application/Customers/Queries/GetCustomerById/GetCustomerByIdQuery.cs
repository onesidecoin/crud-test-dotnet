using AutoMapper;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos.Customer;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCustomer
{
    public record GetCustomerByIdQuery : IRequest<CustomerDto>
    {
        public Guid Id { get; set; }
    }

    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public GetCustomerByIdQueryHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }

        public async Task<CustomerDto> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var customer = await _repo.GetByIdAsync(request.Id);
            return _mapper.Map<CustomerDto>(customer);
        }
    }

}
