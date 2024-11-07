using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.API.Abstractions.Auth;

public interface IUserAccessor
{
	string GetCurrentUsername();
	RoleAccess GetCurrentUserRole();
}
