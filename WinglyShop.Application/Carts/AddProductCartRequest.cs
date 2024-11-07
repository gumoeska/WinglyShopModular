namespace WinglyShop.Application.Carts;

public record AddProductCartRequest(int cartId, int productId, int quantity);
