using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Shared;

namespace WinglyShop.Application.Roles.Get;

internal sealed class GetRolesQueryHandler : IQueryHandler<GetRolesQuery, List<Role>>
{
    private readonly IDatabaseContext _context;

    public GetRolesQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Role>>> Handle(GetRolesQuery query, CancellationToken cancellationToken)
    {
        var listOfRoles = _context.Roles.ToList();

        if (listOfRoles.IsNullOrEmpty())
        {
            return Result.Failure<List<Role>>(new Error("Error", "An error occured."));
        }

        return Result.Success(listOfRoles);
    }
}
