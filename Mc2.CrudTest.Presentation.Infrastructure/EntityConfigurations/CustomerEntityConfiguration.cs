using Mc2.CrudTest.Presentation.Domain.Constants;
using Mc2.CrudTest.Presentation.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Mc2.CrudTest.Presentation.Infrastructure.EntityConfigurations
{
    public class CustomerEntityConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {

            builder.HasIndex(s => new { s.Firstname, s.Lastname , s.DateOfBirth });
            builder.HasIndex(s => s.Email);

            builder.Property(s => s.Firstname).HasColumnType("varchar").HasMaxLength(EntityConfigurationConsts.FirstnameMaxLength).IsRequired();
            builder.Property(s => s.Lastname).HasColumnType("varchar").HasMaxLength(EntityConfigurationConsts.LastnameMaxLength).IsRequired();
            builder.Property(s => s.PhoneNumber).HasColumnType("varchar").HasMaxLength(EntityConfigurationConsts.PhoneNumberMaxLength).IsRequired();
            builder.Property(s => s.Email).HasColumnType("varchar").HasMaxLength(EntityConfigurationConsts.EmailMaxLength).IsRequired();
        }
    }
}
