namespace Discount.API.Extensions
{
    public static class DbInitializerExtension
    {
        public static IApplicationBuilder UseItToSeed(this IApplicationBuilder app)
        {
            ArgumentNullException.ThrowIfNull(app, nameof(app));

            return HostExtensions.MigrateDatabase<Program>(app);
        }
    }
}
