using System;
using System.Collections.Generic;
using WinglyShop.Domain.Entities.Addresses;
using WinglyShop.Domain.Entities.Orders;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Entities.OrderDetails;

public partial class OrderDetail
{
    public int Id { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? IdOrder { get; set; }

    public int? IdProduct { get; set; }

    public int? IdAddress { get; set; }

    public virtual Address? IdAddressNavigation { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
