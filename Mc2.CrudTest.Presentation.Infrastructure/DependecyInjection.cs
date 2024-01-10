using Mc2.CrudTest.Presentation.Infrastructure.Data;
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

            services.AddPooledDbContextFactory<AppDbContext>(s =>

                     s.UseSqlServer(connectionString, m =>
                     {
                         m.CommandTimeout(180);
                     })
                     .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                );

            return services;
        }

    }
}
