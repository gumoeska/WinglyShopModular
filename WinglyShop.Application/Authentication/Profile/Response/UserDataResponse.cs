namespace WinglyShop.Application.Authentication.Profile.Response;

public sealed record UserDataResponse(
	string? Username, 
	string? Surname, 
	string? Email, 
	string? Image,
	string? Role);
