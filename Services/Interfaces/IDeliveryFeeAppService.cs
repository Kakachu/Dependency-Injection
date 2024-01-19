namespace DependencyStore.Services.Interfaces
{
	public interface IDeliveryFeeAppService
	{
		Task<decimal> GetDeliveryFee(string zipCode);
	}
}
