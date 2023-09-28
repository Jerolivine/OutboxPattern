using Microsoft.Extensions.DependencyInjection;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Persistance.EFCore;
using OutboxPattern.Persistance.EFCore.Repository;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        public static void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<EFCoreDbContext>();

            AddRepositories(services);
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerAddedOutboxRepository, CustomerAddedOutboxRepository>();
        }
    }
}
