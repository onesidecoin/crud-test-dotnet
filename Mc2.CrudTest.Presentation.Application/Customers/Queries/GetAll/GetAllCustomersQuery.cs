using AutoMapper;
using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Shared.Dtos.Customer;
using MediatR;

namespace Mc2.CrudTest.Presentation.Application.Customers.Queries.GetAll
{
	public class GetAllCustomersQuery : IRequest<IEnumerable<CustomerDto>>
	{
	}


	public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
	{
		private readonly ICustomerRepository _repo;
		private readonly IMapper _mapper;

		public GetAllCustomersQueryHandler(ICustomerRepository repo, IMapper mapper)
		{
			_repo = repo;
			_mapper=mapper;
		}

		public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
		{
			var customers = await _repo.GetAll();
			var dtos = _mapper.Map<List<CustomerDto>>(customers);

			return dtos;
		}
	}

}
