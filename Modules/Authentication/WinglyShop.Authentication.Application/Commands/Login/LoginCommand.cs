using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.DTOs;

namespace WinglyShop.Authentication.Application.Commands.Login;

public sealed record LoginCommand(string Login, string Password) : ICommand<LoginUserResultDTO>;
