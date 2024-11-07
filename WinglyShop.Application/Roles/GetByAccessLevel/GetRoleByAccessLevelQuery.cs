using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Roles;

namespace WinglyShop.Application.Roles.GetByAccessLevel;

public sealed record GetRoleByAccessLevelQuery(RoleAccess AccessLevel) : IQuery<Role>;
