using System;
using System.Collections.Generic;
using WinglyShop.Domain.Entities.Carts;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Entities.CartDetails;

public partial class CartDetail
{
    public int Id { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public int? IdCart { get; set; }

    public int? IdProduct { get; set; }

    public virtual Cart? IdCartNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
