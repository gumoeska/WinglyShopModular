using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Authentication.DTOs;

public sealed record LoginUserResultDTO(User User, Role Role);
