using WinglyShop.Domain.Entities.CartDetails;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Domain.Entities.Carts;

public partial class Cart
{
    public int Id { get; set; }

    public decimal? TotalValue { get; set; }

    public bool? IsActive { get; set; }

    public int? IdUser { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual User? IdUserNavigation { get; set; }
}
