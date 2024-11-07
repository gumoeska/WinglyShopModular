using WinglyShop.Domain.Common.DTOs.Users;
using WinglyShop.Domain.Entities.Addresses;
using WinglyShop.Domain.Entities.Carts;
using WinglyShop.Domain.Entities.Orders;
using WinglyShop.Domain.Entities.Roles;

namespace WinglyShop.Domain.Entities.Users;

public partial class User
{
    public User()
    {
    }

    public User(UserDTO user)
    {
        Login = user.Login;
        Email = user.Email;
        Password = user.Password;
        Name = user.Name;
        Surname = user.Surname;
        Image = user.Image;
        Phone = user.Phone;
    }

    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Image { get; set; }

    public string? Phone { get; set; }

    public bool? IsActive { get; set; }

    public int? IdRole { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Role? IdRoleNavigation { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
