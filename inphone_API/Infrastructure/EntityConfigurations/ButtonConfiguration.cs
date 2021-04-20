using inphone_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inphone_API.Infrastructure.EntityConfigurations
{
    public class ButtonConfiguration : IEntityTypeConfiguration<Button>
    {
        public void Configure(EntityTypeBuilder<Button> builder)
        {
            builder.ToTable("Button");
            builder.HasKey(ci => ci.IdButton);
            builder.Property(ci => ci.IdButton).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Label).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Content).HasMaxLength(255).IsRequired();
            builder.Property(p => p.LastModificationDate).HasDefaultValueSql("getdate()");
            builder.HasOne(p => p.Customer).WithMany(p => p.Buttons).HasForeignKey(x => x.IdCustomer);
            builder.HasOne(p => p.TypeButton).WithMany(p => p.Buttons).HasForeignKey(p => p.Type);
        }
    }
}
