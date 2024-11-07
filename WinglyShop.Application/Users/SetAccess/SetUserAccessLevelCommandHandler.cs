using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

namespace WinglyShop.Application.Users.SetAccess;

internal sealed class SetUserAccessLevelCommandHandler : ICommandHandler<SetUserAccessLevelCommand, bool>
{
	private readonly IDatabaseContext _context;

    public SetUserAccessLevelCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(SetUserAccessLevelCommand command, CancellationToken cancellationToken)
    {
        // Validation
        if (command is null)
        {
            return Result.Failure<bool>(new Error("Error", "Null Access Level."));
        }

        // Get the user
        var user = await _context.Users
            .Where(x => x.Id == command.UserId)
            .FirstOrDefaultAsync();

        // Validation
        if (user is null)
        {
            return Result.Failure<bool>(new Error("Error", "This user doesn't exist."));
        }

        // Checking if there's a role with the selected accessLevel
        var role = await _context.Roles
            .Where(x => x.Access == (RoleAccess)command.AccessLevel)
            .FirstOrDefaultAsync();

        if (role is null)
        {
            return Result.Failure<bool>(new Error("Error", "A role with this accessLevel doesn't exist."));
        }

        // Setting the user access level
        try
        {
            user.IdRole = role.Id;

            // Updating data
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "An error has occurred."));
        }

        return Result.Success(true);
    }
}
