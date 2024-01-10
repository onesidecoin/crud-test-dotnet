using Mc2.CrudTest.Presentation.Domain.Entities;
using Mc2.CrudTest.Presentation.Infrastructure.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Mc2.CrudTest.Presentation.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(CustomerEntityConfiguration)));
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
