using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.API.Extensions.Authorization;

public static class AuthorizationLevelExtension
{
	public static bool HasAccess(int userAccessLevel, RoleAccess requiredAccessLevel)
	{
		return userAccessLevel >= (int)requiredAccessLevel;
	}
}
