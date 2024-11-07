using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Users;

namespace WinglyShop.Authentication.Application.Commands.Register;

public sealed record RegisterCommand(UserDTO User) : ICommand<bool>;
