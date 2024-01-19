using DependencyStore.Models;

namespace DependencyStore.Repositories.Interfaces
{
	public interface ICustomerRepository
	{
		Task<Customer?> GetById(string customerId);
	}
}
