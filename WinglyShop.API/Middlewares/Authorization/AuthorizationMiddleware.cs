using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WinglyShop.API.Middlewares.Authorization;

public class AuthorizationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthorizationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        //var user = context.User;

        //if (user.Identity.IsAuthenticated)
        //{
        //    var roleClaim = ((ClaimsIdentity)user.Identity).FindFirst("role");
        //    if (roleClaim != null)
        //    {
        //        if (roleClaim.Value == "Admin")
        //        {
        //        }
        //        else if (roleClaim.Value == "Customer")
        //        {
        //        }
        //    }
        //    else
        //    {
        //        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        //        return;
        //    }
        //}

        await _next.Invoke(context);
    }
}
