using WinglyShop.Users.Domain.Entities.Users;

namespace WinglyShop.Users.Domain.Entities.Addresses;

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
}
