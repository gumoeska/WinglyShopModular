using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.Application.Roles.GetByAccessLevel;

public sealed record GetRoleByAccessLevelRequest(RoleAccess AccessLevel);
