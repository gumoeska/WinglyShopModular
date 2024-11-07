using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Shared;

namespace WinglyShop.Application.Roles.GetById;

internal sealed class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, Role>
{
    private readonly IDatabaseContext _context;

    public GetRoleByIdQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<Role>> Handle(GetRoleByIdQuery query, CancellationToken cancellationToken)
    {
        if (query is null)
        {
            return Result.Failure<Role>(new Error("Error", "An error occured."));
        }

        var role = await _context.Roles
            .Where(x => x.Id == query.roleId)
            .FirstOrDefaultAsync();

        if (role is null)
        {
            return Result.Failure<Role>(new Error("Error", "This role doesn't exist."));
        }

        return Result.Success(role);
    }
}
