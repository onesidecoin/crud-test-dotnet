using Mc2.CrudTest.Presentation.Application.Customers.Commands.CreateCustomer;
using Mc2.CrudTest.Presentation.Application.MapperProfiles;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Application.Extentions
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateCustomerCommand).Assembly));
			services.AddAutoMapper(Assembly.GetAssembly(typeof(CustomerMapperProfile)));

			return services;
        }
    }
}
