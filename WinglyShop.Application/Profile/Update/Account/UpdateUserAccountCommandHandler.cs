using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

namespace WinglyShop.Application.Profile.Update.Account;

internal sealed class UpdateUserAccountCommandHandler : ICommandHandler<UpdateUserAccountCommand, bool>
{
    private readonly IDatabaseContext _context;

    public UpdateUserAccountCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateUserAccountCommand command, CancellationToken cancellationToken)
    {
        // Updating the user profile information
        try
        {
            var updatedUser = await _context.Users
                .Where(x => x.Login == command.Username)
                .ExecuteUpdateAsync(x => x
                    .SetProperty(user => user.Password, command.Request.Password)
                    .SetProperty(user => user.Email, command.Request.Email));

            // Updating data
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao alterar as informações."));
        }

        return Result.Success(true);
    }
}
