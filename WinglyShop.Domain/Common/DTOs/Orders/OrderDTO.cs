using WinglyShop.Domain.Common.Enums.Order;
using WinglyShop.Domain.Common.Enums.Payment;
using WinglyShop.Domain.Entities.OrderDetails;

namespace WinglyShop.Domain.Common.DTOs.Orders;

public sealed record OrderDTO(
	int UserId, 
	DateTime Date, 
	OrderStatus Status, 
	PaymentMethod PaymentMethod, 
	decimal TotalValue, 
	ICollection<OrderDetail> OrderDetails);