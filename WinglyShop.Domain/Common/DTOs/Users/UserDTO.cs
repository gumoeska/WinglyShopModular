namespace WinglyShop.Domain.Common.DTOs.Users;

public sealed record UserDTO(
    string Login,
    string Email,
    string Password,
    string Name,
    string Surname,
    string Image,
    string Phone);
