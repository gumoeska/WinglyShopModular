using WinglyShop.Users.Application.Commands.DTOs;
using WinglyShop.Infrastructure.Abstractions.Messaging;

namespace WinglyShop.Users.Application.Commands.Login;

public sealed record LoginCommand(string Login, string Password) : ICommand<LoginUserResultDTO>;
