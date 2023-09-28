using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Persistance.EFCore;
using OutboxPattern.Persistance.EFCore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        public static void ConfigureEfCore(IServiceCollection services)
        {
            services.AddDbContext<EFCoreDbContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
        }
    }
}
