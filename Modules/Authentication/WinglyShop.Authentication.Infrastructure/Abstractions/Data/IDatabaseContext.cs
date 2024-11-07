using Microsoft.EntityFrameworkCore;
using WinglyShop.Users.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WinglyShop.Users.Infrastructure.Abstractions.Data;

namespace WinglyShop.Infrastructure.Abstractions.Data;

public interface IDatabaseContext : TesteInterface
{
	DbSet<User> Users { get; set; }

	Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

	// Additional Props

	
}
