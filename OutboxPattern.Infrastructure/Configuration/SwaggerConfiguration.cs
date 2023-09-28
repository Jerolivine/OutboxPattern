using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace OutboxPattern.Infrastructure.Configuration
{
    public static partial class Configuration
    {
        public static void ConfigureSwagger(IServiceCollection services)
        {
            // Add services required for Swagger
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Outbox Pattern API", Version = "v1" });
            });
        }

        public static void ConfigureSwagger(WebApplication app)
        {
            // Configure Swagger and the Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Outbox Pattern API V1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
