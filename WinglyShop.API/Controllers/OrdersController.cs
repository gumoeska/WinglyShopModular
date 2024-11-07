using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Orders.DeleteOrder;
using WinglyShop.Application.Orders.GetOrder;
using WinglyShop.Application.Orders.PlaceOrder;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class OrdersController : ApiController
{
    public OrdersController(
		IDatabaseContext databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
    }

	[HttpPost("PlaceOrder")]
	public async Task<IActionResult> PlaceOrder([FromBody] PlaceOrderRequest request, CancellationToken cancellationToken)
	{
		// Creating the command

		return Ok();



	}

	[HttpGet("GetOrder")]
	public async Task<IActionResult> GetOrderById([FromBody] GetOrderRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		//var command = new GetOrderCommand();

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpDelete("DeleteOrder")]
	public async Task<IActionResult> DeleteOrderById([FromBody] DeleteOrderRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		//var command = new GetOrderCommand();

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}
}
