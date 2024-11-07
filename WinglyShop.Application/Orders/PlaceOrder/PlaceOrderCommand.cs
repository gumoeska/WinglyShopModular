using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Orders;

namespace WinglyShop.Application.Orders.PlaceOrder;

public sealed record PlaceOrderCommand(Order order) : ICommand<bool>;