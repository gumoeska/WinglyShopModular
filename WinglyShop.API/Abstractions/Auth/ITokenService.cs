using WinglyShop.Users.Application.Commands.DTOs;

namespace WinglyShop.API.Abstractions.Auth;

public interface ITokenService
{
	string GenerateToken(LoginUserResultDTO user);
}
