using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Extensions.Authorization;
using WinglyShop.API.Extensions.Common;
using WinglyShop.Domain.Common.Enums.Account;

namespace WinglyShop.API.Attributes;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public class AuthAccessLevelAttribute : AuthorizeAttribute, IAuthorizationFilter
{
	private readonly RoleAccess _requiredAccessLevel;

    public AuthAccessLevelAttribute(RoleAccess requiredAccessLevel)
    {
		_requiredAccessLevel = requiredAccessLevel;
	}

    public void OnAuthorization(AuthorizationFilterContext context)
	{
		if (!context.HttpContext.User.Identity.IsAuthenticated)
		{
			context.Result = new UnauthorizedResult();
			return;
		}

		int userAccessLevel = GetUserAccessLevel(context.HttpContext.User);

		if (!AuthorizationLevelExtension.HasAccess(userAccessLevel, _requiredAccessLevel))
		{
			//context.Result = new ForbidResult();
			context.Result = new UnauthorizedResult();
			return;
		}
	}

	private int GetUserAccessLevel(ClaimsPrincipal user)
	{
		var roleData = user.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;

		var role = EnumExtension.GetEnumValueFromName<RoleAccess>(roleData ?? string.Empty);

		return (int)role;
	}
}
