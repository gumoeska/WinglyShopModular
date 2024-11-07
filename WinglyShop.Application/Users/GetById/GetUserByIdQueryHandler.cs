using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;

namespace WinglyShop.Application.Users.GetById;

internal sealed class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, User?>
{
    private readonly IDbConnection _dbConnection;
    private readonly IDatabaseContext _context;

    public GetUserByIdQueryHandler(IDbConnection dbConnection, IDatabaseContext context)
        => (_dbConnection, _context) = (dbConnection, context);

    public async Task<Result<User?>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
    {
        var test = await _context.Users.Where(x => x.Id == 1).FirstOrDefaultAsync();

        return Result.Success(test);
    }
}
