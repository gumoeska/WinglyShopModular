using System;
using System.Collections.Generic;
using WinglyShop.Domain.Entities.OrderDetails;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Domain.Entities.Addresses;

public partial class Address
{
    public int Id { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public string? Country { get; set; }

    public string? PostalCode { get; set; }

    public bool? IsActive { get; set; }

    public int? IdUser { get; set; }

    public virtual User? IdUserNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
