using Microsoft.Extensions.DependencyInjection;
using OutboxPattern.Application.Interfaces;
using OutboxPattern.Application.Services;
using OutboxPattern.Domain.Customer;
using OutboxPattern.Persistance.EFCore.Repository;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        public static void InjectServices(IServiceCollection services)
        {
            //InjectService<IBusinessService>(services);
            //InjectService<IBusinessRepository>(services);

            services.AddTransient<ICustomerService, CustomerService>();
        }

        private static void InjectService<TInterface>(IServiceCollection services)
        {
            //services.Scan(scan => scan
            //        .FromAssemblyOf<TInterface>()
            //        .AddClasses(classes => classes.AssignableTo<TInterface>())
            //        .AsImplementedInterfaces()
            //        .WithTransientLifetime());
        }
    }
}
