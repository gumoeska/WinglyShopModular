using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Users;

namespace WinglyShop.Users.Application.Commands.Register;

public sealed record RegisterCommand(UserDTO User) : ICommand<bool>;
