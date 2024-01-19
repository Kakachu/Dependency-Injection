using DependencyStore;
using DependencyStore.Configurations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Configuration>();

builder.Services.AddDependencyExtensions();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();