using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories
{
	public class ProductRepository : IProductRepository
	{
		private readonly SqlConnection _connection;

		public ProductRepository(SqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<Product?> GetProductById(int productId)
		{
			const string getProductQuery = "SELECT [Id], [Name], [Price] FROM PRODUCT WHERE ID=@id";
			return await _connection.QueryFirstAsync<Product>(getProductQuery, new { Id = productId });
		}
	}
}
