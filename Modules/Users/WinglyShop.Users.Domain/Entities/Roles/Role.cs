using WinglyShop.Users.Domain.Common.Enums.Account;
using WinglyShop.Users.Domain.Entities.Users;

namespace WinglyShop.Users.Domain.Entities.Roles;

public partial class Role
{
    public int Id { get; set; }

    public RoleAccess Access { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
