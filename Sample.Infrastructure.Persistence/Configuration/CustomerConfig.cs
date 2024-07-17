using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Sample.Domain.Entities;

namespace Sample.Infrastructure.Persistence.Configuration;

public class CustomerConfig : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder)
    {

        builder
            .HasIndex(c => new { c.FirstName, c.LastName, c.DateOfBirth })
            .IsUnique();

        builder
            .HasIndex(c => c.Email)
            .IsUnique();

        builder.Property(e => e.PhoneNumber)
            .HasMaxLength(11)
            .IsFixedLength()
            .IsUnicode(false);
    }
}
