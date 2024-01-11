using AutoMapper;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos.Customer;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.GetCusomers
{
    public record GetCustomersQuery : IRequest<IEnumerable<CustomerDto>>
    {
        public GetCustomersQuery()
        {
            Ids = new List<Guid>();
        }

        public IEnumerable<Guid> Ids { get; set; }
    }

    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly ICustomerRepository _repo;
        private readonly IMapper _mapper;

        public GetCustomersQueryHandler(ICustomerRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper=mapper;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await _repo.GetByIdsAsync(request.Ids);
            var dtos = _mapper.Map<List<CustomerDto>>(customers);

            return dtos;
        }
    }


}
