using WinglyShop.Domain.Entities.Addresses;
using WinglyShop.Domain.Entities.Orders;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Common.DTOs.OrderDetails;

public sealed record OrderDetailDTO(
	int OrderId, 
	int Quantity, 
	decimal Price, 
	int ProductId, 
	int AddressId);
