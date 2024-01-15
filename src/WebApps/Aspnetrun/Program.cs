using Aspnetrun.Services;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

//builder.Services.AddServices(configuration);
// Add services to the container.

builder.Services.AddHttpClient<ICatalogService, CatalogService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});

builder.Services.AddHttpClient<IBasketService, BasketService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});

builder.Services.AddHttpClient<IOrderService, OrderService>(c =>
{
    c.BaseAddress = new Uri(builder.Configuration["ApiSettings:GatewayAddress"]);
});

builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    // Seed data for mssqlserver
    //app.UseItToSeed();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
