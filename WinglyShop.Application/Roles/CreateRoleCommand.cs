using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Roles;

namespace WinglyShop.Application.Roles;

public sealed record CreateRoleCommand(Role Role) : ICommand<bool>;
