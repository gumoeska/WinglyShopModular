using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Users.GetById;

public sealed record GetUserByIdQuery(int userId) : IQuery<User?>;
