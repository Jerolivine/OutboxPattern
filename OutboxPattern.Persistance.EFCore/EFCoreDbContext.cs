using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OutboxPattern.Domain.Customer;

namespace OutboxPattern.Persistance.EFCore
{
    public class EFCoreDbContext : DbContext
    {

        public DbSet<Customer> Customer { get; set; }

        public IConfiguration Configuration { get; }

        public EFCoreDbContext(DbContextOptions<EFCoreDbContext> options, IConfiguration configuration)
          : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = Configuration.GetConnectionString("OutboxPatternDB");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EFCoreDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
