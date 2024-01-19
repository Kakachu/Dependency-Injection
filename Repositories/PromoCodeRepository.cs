using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Interfaces;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories
{
	public class PromoCodeRepository : IPromoCodeRepository
	{
		private readonly SqlConnection _connection;

		public PromoCodeRepository(SqlConnection connection)
			=> _connection = connection;

		public async Task<PromoCode?> GetPromoCode(string code)
		{
			const string query = "SELECT * FROM PROMO_CODES WHERE CODE=@code";
			return await _connection.QueryFirstAsync<PromoCode>(query, new { code = code });
		}
	}
}
