namespace WinglyShop.Users.Application.Queries.Responses;

public sealed record UserDataResponse(
    string? Username,
    string? Surname,
    string? Email,
    string? Image,
    string? Role);
