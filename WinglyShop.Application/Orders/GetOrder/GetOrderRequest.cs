namespace WinglyShop.Application.Orders.GetOrder;

public record GetOrderRequest(int userId, Guid userToken, int orderId);
