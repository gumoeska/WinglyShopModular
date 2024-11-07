using WinglyShop.Domain.Entities.Carts;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;
using WinglyShop.Application.Abstractions.Data;
using Microsoft.EntityFrameworkCore;

namespace WinglyShop.Application.Carts.Get;

internal sealed class GetCartQueryHandler : IQueryHandler<GetCartQuery, Cart?>
{
	private readonly IDatabaseContext _context;

    public GetCartQueryHandler(IDatabaseContext context) => 
		(_context) = (context);

    public async Task<Result<Cart?>> Handle(GetCartQuery query, CancellationToken cancellationToken)
	{
		// Validate
		if (query is null)
			throw new ArgumentNullException(nameof(query));

		// Get the cart
		var cart = await _context.Carts
			.Where(x => x.Id == query.CartId)
			.FirstOrDefaultAsync();

		// Validate the cart
		if (cart is null)
			return Result.Failure<Cart?>(new Error("Error", "This cart doesn't exist."));

		return Result.Success(cart);
	}
}
