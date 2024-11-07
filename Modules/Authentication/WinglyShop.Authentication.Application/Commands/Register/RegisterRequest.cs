using WinglyShop.Domain.Common.DTOs.Users;

namespace WinglyShop.Authentication.Application.Commands.Register;

public sealed record RegisterRequest(
	string Login,
	string Email,
	string Password,
	string Name,
	string Surname,
	string Image,
	string Phone);
