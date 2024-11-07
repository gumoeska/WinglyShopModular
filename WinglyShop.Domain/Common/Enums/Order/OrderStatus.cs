using System.ComponentModel;

namespace WinglyShop.Domain.Common.Enums.Order;

public enum OrderStatus
{
	[Description("New Order")]
	NewOrder,

	[Description("Pending Payment")]
	PendingPayment,

	[Description("Payment Received")]
	PaymentReceived,

	[Description("Order Invoiced")]
	OrderInvoiced,

	[Description("Order Shipped")]
	OrderShipped,

	[Description("Order Completed")]
	OrderCompleted,

	[Description("Order Archived")]
	OrderArchived
}
