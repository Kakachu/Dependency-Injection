using DependencyStore.Models;

namespace DependencyStore.Repositories.Interfaces
{
	public interface IProductRepository
	{
		Task<Product?> GetProductById(int productId);
	}
}
