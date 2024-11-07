using Microsoft.EntityFrameworkCore;
using WinglyShop.Infrastructure.Abstractions.Data;
using WinglyShop.Infrastructure.Abstractions.Messaging;
using WinglyShop.Shared;
using WinglyShop.Users.Application.Commands.DTOs;
using WinglyShop.Users.Infrastructure.Abstractions.Data;

namespace WinglyShop.Users.Application.Commands.Login;

internal sealed class LoginCommandHandler : ICommandHandler<LoginCommand, LoginUserResultDTO>
{
    private readonly IDbConnection _dbConnection;
    private readonly IDatabaseContext _context;

    public LoginCommandHandler(IDbConnection dbConnection, IDatabaseContext dbContext)
        => (_dbConnection, _context) = (dbConnection, dbContext);

    public async Task<Result<LoginUserResultDTO>> Handle(LoginCommand command, CancellationToken cancellationToken)
    {
        // Validate
        if (command is null)
            throw new ArgumentNullException(nameof(command));

        // Try to return the user
        var user = await _context.Users
            .Where(x => x.Login == command.Login
                     && x.Password == command.Password)
            .FirstOrDefaultAsync();

        // Validate the user
        if (user is null)
        {
            return Result.Failure<LoginUserResultDTO>(new Error("Error", "Esta conta não existe."));
        }

        // if the user is not null, return the role
        var role = await _context.Roles
            .Where(x => x.Id == user.IdRole)
            .FirstOrDefaultAsync();

        if (role is null)
        {
            return Result.Failure<LoginUserResultDTO>(new Error("Error", "Permissão Inválida."));
        }

        // Building the object
        var userData = new LoginUserResultDTO(user, role);

        return Result.Success(userData);
    }
}
