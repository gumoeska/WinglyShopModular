using Microsoft.EntityFrameworkCore;
using WinglyShop.Infrastructure.Abstractions.Data;
using WinglyShop.Users.Domain.Entities.Roles;
using WinglyShop.Users.Domain.Entities.Users;

namespace WinglyShop.Users.Infrastructure.Abstractions.Data;

public interface IDatabaseContext : IDatabaseContextBase
{
	DbSet<User> Users { get; set; }
	DbSet<Role> Roles { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
