using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Users.Update;

public sealed record UpdateUserCommand(User user) : ICommand<bool>;
