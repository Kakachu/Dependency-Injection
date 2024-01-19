using DependencyStore;
using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services;
using DependencyStore.Services.Interfaces;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();

builder.Services.AddScoped(x 
	=> new SqlConnection("CONNECTION_STRING"));

builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
builder.Services.AddTransient<IDeliveryFeeAppService, DeliveryFeeAppServices>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();