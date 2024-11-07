using WinglyShop.Users.Domain.Common.DTOs.Users;
using WinglyShop.Users.Domain.Entities.Addresses;
using WinglyShop.Users.Domain.Entities.Roles;

namespace WinglyShop.Users.Domain.Entities.Users;

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

    public virtual Role? IdRoleNavigation { get; set; }
}
