using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Wishlist;

public sealed record AddProductWishlistCommand(int userId, int productId) : ICommand<bool>;
