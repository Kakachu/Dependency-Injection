using DependencyStore.Models;

namespace DependencyStore.Repositories.Interfaces
{
	public interface IPromoCodeRepository
	{
		Task<PromoCode?> GetPromoCode(string code);
	}
}
