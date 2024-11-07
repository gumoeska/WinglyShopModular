using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Roles;

namespace WinglyShop.Application.Roles.GetById;

public sealed record GetRoleByIdQuery(int roleId) : IQuery<Role>;
