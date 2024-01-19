﻿using DependencyStore.Repositories;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services;
using DependencyStore.Services.Interfaces;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Extensions
{
	public static class DependenciesExtension
	{
		public static void AddSqlConnection(this IServiceCollection services, string connectionString)
		{
			services.AddScoped(x => new SqlConnection(connectionString));
		}

		public static void AddRepositories(this IServiceCollection services)
		{
			services.AddTransient<ICustomerRepository, CustomerRepository>();
			services.AddTransient<IProductRepository, ProductRepository>();
			services.AddTransient<IPromoCodeRepository, PromoCodeRepository>();
		}

		public static void AddServices(this IServiceCollection services)
		{
			services.AddTransient<IDeliveryFeeAppService, DeliveryFeeAppServices>();
		}
	}
}
