using DependencyStore.Extensions;

namespace DependencyStore.Configurations
{
	public static class DependencyExtensionConfiguration
	{
		public static void AddDependencyExtensions(this IServiceCollection services)
		{
			services.AddSqlConnection("");

			services.AddRepositories();

			services.AddServices();
		}
	}
}
