using OutboxPattern.Jobs.Outbox.Jobs;
using Quartz;

namespace OutboxPattern.API.Extensions.Configuration
{
    public static partial class Configuration
    {
        public static void ConfigureQuartzJobs(IServiceCollection services)
        {
            services.AddQuartz(q =>
            {
                q.UseMicrosoftDependencyInjectionJobFactory();

                CustomerAddedConsumerJob(q);
            });

            services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        }

        private static void CustomerAddedConsumerJob(IServiceCollectionQuartzConfigurator q)
        {
            // Create a "key" for the job
            var jobKey = new JobKey("CustomerAddedJob");

            // Register the job with the DI container
            q.AddJob<CustomerAddedJob>(opts => opts.WithIdentity(jobKey));

            // Create a trigger for the job
            q.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity("CustomerAddedJob-trigger")
                .WithCronSchedule("0/5 * * ? * * *")); // 5 seconds
        }
    }
}
