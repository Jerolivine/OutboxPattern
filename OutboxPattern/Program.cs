using OutboxPattern.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

Configuration.ConfigureSwagger(builder.Services);
Configuration.ConfigureEfCore(builder.Services);
Configuration.InjectServices(builder.Services);
Configuration.ConfigureCORS(builder.Services);

OutboxPattern.API.Extensions.Configuration.Configuration.ConfigureQuartzJobs(builder.Services);
OutboxPattern.API.Extensions.Configuration.Configuration.AddMassTransitWithRabbitMqTransport(builder.Services,builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.MapControllers();

Configuration.ConfigureSwagger(app);
Configuration.ConfigureCORS(app);

app.Run();
