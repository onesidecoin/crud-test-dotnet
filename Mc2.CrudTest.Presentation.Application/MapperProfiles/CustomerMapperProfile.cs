using AutoMapper;
using Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Application.Dtos;
using Mc2.CrudTest.Presentation.Domain.Entities;

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
