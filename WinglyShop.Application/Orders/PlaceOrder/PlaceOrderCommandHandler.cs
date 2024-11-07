using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Orders.PlaceOrder;

internal sealed class PlaceOrderCommandHandler : ICommandHandler<PlaceOrderCommand, bool>
{
	private readonly IDatabaseContext _context;

    public PlaceOrderCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(PlaceOrderCommand command, CancellationToken cancellationToken)
	{
		// Validate
		if (command is null)
			throw new ArgumentNullException(nameof(command));

		try
		{
			// Placing the Order



			// Placing the Order Details



		}
		catch (Exception ex)
		{

		}

		return false;

	}
}
