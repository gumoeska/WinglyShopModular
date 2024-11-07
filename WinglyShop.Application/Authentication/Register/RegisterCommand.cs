using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Users;

namespace WinglyShop.Application.Authentication.Register;

public sealed record RegisterCommand(UserDTO User) : ICommand<bool>;