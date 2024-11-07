using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Carts;

public sealed record AddProductCartCommand(int cartId, int productId, int quantity) : ICommand<bool>;
