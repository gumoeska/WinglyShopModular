using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Carts;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class CartController : ApiController
{
    public CartController(
		IDatabaseContext databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher, 
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
    }

	[HttpGet]
	public async Task<IActionResult> GetCart([FromBody] AddProductCartRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		var command = new AddProductCartCommand(
			request.cartId,
			request.productId,
			request.quantity);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}

	[HttpPost("AddProduct")]
	public async Task<IActionResult> AddProduct([FromBody] AddProductCartRequest request, CancellationToken cancellationToken)
	{
		if (request is null)
			return null;

		var command = new AddProductCartCommand(
			request.cartId, 
			request.productId, 
			request.quantity);

		//Result<string> tokenResult = await _dispatcher.Send<LoginCommand, string>(command, cancellationToken);

		//if (tokenResult.IsFailure)
		//	return null;

		Result<string> tokenResult = "Test";

		return Ok(tokenResult);
	}
}
