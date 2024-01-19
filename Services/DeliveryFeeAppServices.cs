using DependencyStore.Services.Interfaces;
using RestSharp;

namespace DependencyStore.Services
{
	public class DeliveryFeeAppServices : IDeliveryFeeAppService
	{
		private readonly Configuration _configuration;

		public DeliveryFeeAppServices(Configuration configuration)
        {
            _configuration = configuration;
        }
        public async Task<decimal> GetDeliveryFee(string zipCode)
		{
			var client = new RestClient(_configuration.DeliveryFeeServiceUrl);
			var request = new RestRequest().AddJsonBody(new { zipCode });

			var response = await client.PostAsync<decimal>(request);


			return response < 5 ? 5 : response;
		}
	}
}
