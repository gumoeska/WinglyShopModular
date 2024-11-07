using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Profile.Update.Account;

public sealed record UpdateUserAccountCommand(UpdateUserAccountRequest Request, string Username) : ICommand<bool>;
