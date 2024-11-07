using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Roles;

internal sealed class CreateRoleCommandHandler : ICommandHandler<CreateRoleCommand, bool>
{
	private readonly IDatabaseContext _context;

    public CreateRoleCommandHandler(IDatabaseContext context)
    {
		_context = context;
    }

    public async Task<Result<bool>> Handle(CreateRoleCommand command, CancellationToken cancellationToken)
	{
        // Validation
        if (command is null)
            return Result.Failure<bool>(Error.NullValue);

		// Variables
        var role = command.Role;

		try
		{
			// Checking if the role already exists
			var roleExists = await _context.Roles
				.AnyAsync(x => x.Access == role.Access);

			// Validade if role already exists
			if (roleExists is true)
				return Result.Failure<bool>(new Error("Error", "Role already exists."));

			// Insert data into database
			await _context.Roles.AddAsync(role);
			await _context.SaveChangesAsync();
		}
		catch (Exception ex)
		{
			return Result.Failure<bool>(new Error("Error", "An error occoured."));
		}

		return Result.Success(true);
	}
}
