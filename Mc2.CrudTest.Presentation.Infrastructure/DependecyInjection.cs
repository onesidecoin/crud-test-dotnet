using Mc2.CrudTest.Presentation.Domain.Interfaces;
using Mc2.CrudTest.Presentation.Infrastructure.Data;
using Mc2.CrudTest.Presentation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Mc2.CrudTest.Presentation.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("AppDbContext");

            services.AddDbContext<AppDbContext>(s =>
                     s.UseSqlServer(connectionString, m =>
                     {
                         m.CommandTimeout(180);
                     })
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );



            services.AddTransient<ICustomerRepository, CustomerRepository>();


            return services;
        }

    }
}
