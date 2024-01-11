using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Shared.Dtos.Customer;

namespace Mc2.CrudTest.Presentation.Application.MapperProfiles
{
	public class CustomerMapperProfile : Profile
	{
		public CustomerMapperProfile()
		{
			CreateMap<Customer, CustomerDto>().ReverseMap();


			// mediatR command to entity mappings
			CreateMap<CreateCustomerCommand, CustomerDto>();
		}
	}
}
