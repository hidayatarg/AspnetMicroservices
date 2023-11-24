using Aspnetrun.Data;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace Aspnetrun.Extensions
{
    public static class HostExtensions
    {
        public static IApplicationBuilder MigrateDatabase<TContext>(this IApplicationBuilder app, int? retry = 0)
           where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var services = scope.ServiceProvider;
                var configuration = services.GetRequiredService<IConfiguration>();
                var logger = services.GetRequiredService<ILogger<TContext>>();
                var context = services.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(TContext).Name);
                    //context.Database.Migrate();
                    Seed(context, services);

                    logger.LogInformation("Migrated database associated with context {DbContextName} completed", typeof(TContext).Name);
                }
                catch (SqlException ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(TContext).Name);

                    if (retryForAvailability < 50)
                    {
                        retryForAvailability++;
                        System.Threading.Thread.Sleep(2000);
                        MigrateDatabase<TContext>(app, retryForAvailability);
                    }
                }
            }

            return app;
        }

        private static void Seed<TContext>(TContext context, IServiceProvider services)
            where TContext : DbContext
        {
            var logger = services.GetRequiredService<ILogger<AspnetrunContext>>();
            AspnetrunContextSeed.SeedAsync(context as AspnetrunContext, (ILoggerFactory)logger).Wait();
        }
    }
}
