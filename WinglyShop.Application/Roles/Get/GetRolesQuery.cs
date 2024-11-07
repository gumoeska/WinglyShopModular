using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Roles;

namespace WinglyShop.Application.Roles.Get;

public sealed record GetRolesQuery() : IQuery<List<Role>>;
