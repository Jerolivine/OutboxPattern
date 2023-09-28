using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        private static readonly string ORIGIN = "OutboxPatternOrigin";

        public static void ConfigureCORS(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(ORIGIN,
                                      policy =>
                                      {
                                          policy.AllowAnyMethod()
                                                .AllowAnyHeader()
                                                .SetIsOriginAllowed((host) => true)
                                                .AllowCredentials();
                                      });
            });
        }

        public static void ConfigureCORS(this WebApplication app)
        {
            app.UseCors(ORIGIN);
        }
    }
}
