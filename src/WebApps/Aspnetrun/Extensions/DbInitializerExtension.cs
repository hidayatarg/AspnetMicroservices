using Aspnetrun.Data;

namespace Aspnetrun.Extensions
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeed(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            return HostExtensions.MigrateDatabase<AspnetrunContext>(app);
        }
    }
}
