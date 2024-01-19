using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Interfaces;
using DependencyStore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using RestSharp;

namespace DependencyStore.Controllers;

public class OrderController : ControllerBase
{
	private readonly ICustomerRepository _customerRepository;
	private readonly IProductRepository _productRepository;
	private readonly IPromoCodeRepository _promoCodeRepository;
	private readonly IDeliveryFeeAppService _deliveryFeeAppService;

	public OrderController(ICustomerRepository customerRepository,
						   IProductRepository productRepository,
						   IPromoCodeRepository promoCodeRepository,
						   IDeliveryFeeAppService deliveryFeeAppService)
	{
		_customerRepository = customerRepository;
		_productRepository = productRepository;
		_promoCodeRepository = promoCodeRepository;
		_deliveryFeeAppService = deliveryFeeAppService;
	}

	[Route("v1/orders")]
	[HttpPost]
	public async Task<IActionResult> Place(string customerId, string zipCode, string promoCode, List<Product> products)
	{
		var customer = _customerRepository.GetById(customerId);
		if (customer == null)
			return NotFound();

		var deliveryFee = await _deliveryFeeAppService.GetDeliveryFee(zipCode);
		var cupon = await _promoCodeRepository.GetPromoCode(promoCode);
		var discount = cupon?.Value ?? 0M;

		decimal subTotal = 0;
		for (var p = 0; p < products.Count; p++)
		{
			var product = await _productRepository.GetProductById(p);
			subTotal += product.Price;
		}

		var order = new Order(deliveryFee, discount, products);
		return Ok(new
		{
			Message = $"Pedido {order.Code} gerado com sucesso!"
		});
	}
}