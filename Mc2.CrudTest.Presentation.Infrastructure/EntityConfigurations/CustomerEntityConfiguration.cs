using Mc2.CrudTest.Presentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Presentation.Infrastructure.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.Property(s => s.Firstname).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(s => s.Lastname).HasColumnType("varchar").HasMaxLength(50).IsRequired();
            builder.Property(s => s.PhoneNumber).HasColumnType("varchar").HasMaxLength(15).IsRequired();
            builder.Property(s => s.Email).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        }
    }
}
