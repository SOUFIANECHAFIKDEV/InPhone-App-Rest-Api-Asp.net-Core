using inphone_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inphone_API.Infrastructure.EntityConfigurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(ci => ci.IdCustomer);
            builder.Property(ci => ci.IdCustomer).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.UserName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Password).HasMaxLength(255).IsRequired();
            builder.Property(p => p.FirstName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.CompanyName).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Phone).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Email).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Logo1).HasColumnType("text");
            builder.Property(p => p.Logo2).HasColumnType("text");
            builder.Property(p => p.Logo3).HasColumnType("text");
            builder.Property(p => p.LastModificationDate).HasDefaultValueSql("getdate()");
            builder.Property(p => p.CreationDate);
            builder.HasMany(x => x.Buttons).WithOne(x => x.Customer).HasForeignKey(x => x.IdCustomer);
        }
    }
}