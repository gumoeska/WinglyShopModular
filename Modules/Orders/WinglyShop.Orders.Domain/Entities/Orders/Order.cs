using WinglyShop.Domain.Common.DTOs.Orders;
using WinglyShop.Domain.Common.Enums.Order;
using WinglyShop.Domain.Common.Enums.Payment;
using WinglyShop.Domain.Entities.OrderDetails;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Domain.Entities.Orders;

public partial class Order
{
    //public Order(OrderDTO order)
    //{
    //    Status = order.Status;
    //    IdUser = order.UserId;
    //    OrderDate = order.Date;
    //    Status = order.Status;
    //    PaymentMethod = order.PaymentMethod;
    //    TotalValue = order.TotalValue;
    //    OrderDetails = order.OrderDetails;
    //}

	//public sealed record OrderDTO(
	//int UserId,
	//DateTime Date,
	//OrderStatus Status,
	//PaymentMethod PaymentMethod,
	//decimal TotalValue,
	//List<OrderDetailDTO> OrderDetails);

	public int Id { get; set; }

    public OrderStatus? Status { get; set; }

    public DateTime? OrderDate { get; set; }

    public PaymentMethod? PaymentMethod { get; set; }

    public decimal? TotalValue { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
