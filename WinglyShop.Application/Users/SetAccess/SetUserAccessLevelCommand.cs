using System.Windows.Input;
using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Users.SetAccess;

public sealed record SetUserAccessLevelCommand(int UserId, int AccessLevel) : ICommand<bool>;
