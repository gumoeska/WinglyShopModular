using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WinglyShop.Application.Users.Get;

internal sealed class GetUsersQueryHandler : IQueryHandler<GetUsersQuery, List<User>>
{
    private readonly IDatabaseContext _context;

    public GetUsersQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<User>>> Handle(GetUsersQuery query, CancellationToken cancellationToken)
	{
		// Validate
        if (query is null)
			throw new ArgumentNullException(nameof(query));

        // Select the list of users
        var users = await _context.Users
            .Where(x => x.IsActive == true)
            .ToListAsync();

        // Validate the list of users
        if (users.IsNullOrEmpty())
            return Result.Failure<List<User>>(new Error("Error", "No users available."));

        // Success
		return Result.Success(users);
	}
}
