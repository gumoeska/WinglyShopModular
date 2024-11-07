using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Users.Get;

public sealed record GetUsersQuery() : IQuery<List<User>>;
