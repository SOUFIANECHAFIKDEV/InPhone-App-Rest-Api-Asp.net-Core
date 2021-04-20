using inphone_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace inphone_API.Infrastructure.EntityConfigurations
{
    public class TypeButtonConfiguration : IEntityTypeConfiguration<TypeButton>
    {
        public void Configure(EntityTypeBuilder<TypeButton> builder)
        {
            builder.ToTable("TypeButton");
            builder.HasKey(ci => ci.IdTypeButton);
            builder.Property(ci => ci.IdTypeButton).ValueGeneratedOnAdd().IsRequired();
            builder.Property(p => p.Label).HasMaxLength(255).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(255).IsRequired();
            builder.HasMany(p => p.Buttons).WithOne(p => p.TypeButton).HasForeignKey(p => p.Type);
        }
    }
}
