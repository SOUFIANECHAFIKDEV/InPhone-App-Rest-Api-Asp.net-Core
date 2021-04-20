using inphone_API.Infrastructure.EntityConfigurations;
using inphone_API.Model;
using Microsoft.EntityFrameworkCore;
using inphone_API.Extensions;

namespace inphone_API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Button> Button { get; set; }
        public DbSet<TypeButton> TypeButton { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new ButtonConfiguration());
            builder.ApplyConfiguration(new TypeButtonConfiguration());
            builder.Seed();
        }
    }
}