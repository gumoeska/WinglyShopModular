using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Profile.Update.Profile;

internal sealed class UpdateUserProfileQueryHandler : ICommandHandler<UpdateUserProfileCommand, bool>
{
    private readonly IDatabaseContext _context;

    public UpdateUserProfileQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UpdateUserProfileCommand command, CancellationToken cancellationToken)
    {
        // Getting the user
        var user = await _context.Users
            .Where(x => x.Login == command.Username)
            .FirstOrDefaultAsync();

        // Validation
        if (user is null)
        {
            return Result.Failure<bool>(new Error("Error", "Usuário inexistente."));
        }

        // Updating the user profile information
        try
        {
            user.Name = command.Request.Name;
            user.Surname = command.Request.Surname;
            user.Phone = command.Request.Phone;

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
