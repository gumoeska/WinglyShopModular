using WinglyShop.Domain.Common.DTOs.Users;

namespace WinglyShop.Application.Authentication.Register;

//public record RegisterRequest(UserDTO User);

public sealed record RegisterRequest(
	string Login,
	string Email,
	string Password,
	string Name,
	string Surname,
	string Image,
	string Phone);
