using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Roles.GetById;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Shared;

namespace WinglyShop.Application.Roles.GetByAccessLevel;

internal sealed class GetRoleByAccessLevelQueryHandler : IQueryHandler<GetRoleByAccessLevelQuery, Role>
{
    private readonly IDatabaseContext _context;

    public GetRoleByAccessLevelQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<Role>> Handle(GetRoleByAccessLevelQuery query, CancellationToken cancellationToken)
    {
        if (query is null)
        {
            return Result.Failure<Role>(new Error("Error", "An error occured."));
        }

        var role = await _context.Roles
            .Where(x => x.Access == query.AccessLevel)
            .FirstOrDefaultAsync();

        if (role is null)
        {
            return Result.Failure<Role>(new Error("Error", "Role not found."));
        }

        return Result.Success(role);
    }
}
