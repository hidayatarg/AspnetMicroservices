namespace Aspnetrun
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {


            //// use in-memory database
            //services.AddDbContext<AspnetRunContext>(c =>
            //    c.UseInMemoryDatabase("AspnetRunConnection"));

            // add database dependecy
            //services.AddDbContext<AspnetrunContext>(c =>
            //    c.UseSqlServer(configuration.GetConnectionString("AspnetRunConnection")));

            // add repository dependecy
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped<ICartRepository, CartRepository>();
            //services.AddScoped<IOrderRepository, OrderRepository>();
            //services.AddScoped<IContactRepository, ContactRepository>();


            return services;
        }
    }
}
