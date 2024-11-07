using WinglyShop.Users.Domain.Entities.Roles;
using WinglyShop.Users.Domain.Entities.Users;

namespace WinglyShop.Users.Application.Commands.DTOs;

public sealed record LoginUserResultDTO(User User, Role Role);
