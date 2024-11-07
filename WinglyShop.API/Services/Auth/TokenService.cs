using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.Application.Authentication.DTOs;

namespace WinglyShop.API.Services.Auth;

public class TokenService : ITokenService
{
	private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GenerateToken(LoginUserResultDTO userData)
	{
		List<Claim> claims = new List<Claim>
		{
			new Claim(ClaimTypes.NameIdentifier, userData.User.Login),
			new Claim(ClaimTypes.Name, userData.User.Name),
			new Claim(ClaimTypes.Surname, userData.User.Surname),
			new Claim("RoleId", userData.User.IdRole.ToString()),
			new Claim(ClaimTypes.Role, userData.Role.Access.GetDisplayName()),
			new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
		};

		var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecretKey:Token"]));

		var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

		var token = new JwtSecurityToken(
			claims: claims,
			expires: DateTime.Now.AddDays(1),
			signingCredentials: credentials);

		var jwt = new JwtSecurityTokenHandler().WriteToken(token);

		return jwt;
	}

	public string GetToken(IHttpContextAccessor contextAccessor)
	{
		var token = contextAccessor.HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

		return token;
	}
}
