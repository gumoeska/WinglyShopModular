using System.Security.Claims;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Extensions.Common;
using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.API.Services.Auth;

public class UserAccessor : IUserAccessor
{
	private readonly IHttpContextAccessor _contextAccessor;

    public UserAccessor(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetCurrentUsername()
	{
        var username = _contextAccessor.HttpContext?.User?.Claims?
            .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

        return username ?? string.Empty;
	}

	public RoleAccess GetCurrentUserRole()
	{
		var roleData = _contextAccessor.HttpContext?.User?.Claims?
			.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

		var role = EnumExtension.GetEnumValueFromDescription<RoleAccess>(roleData ?? string.Empty);

		return role;
	}
}
