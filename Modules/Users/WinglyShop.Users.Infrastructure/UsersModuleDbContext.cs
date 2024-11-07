using Microsoft.EntityFrameworkCore;
using WinglyShop.Users.Domain.Entities.Roles;
using WinglyShop.Users.Domain.Entities.Users;
using WinglyShop.Users.Infrastructure.Abstractions.Data;

namespace WinglyShop.Users.Infrastructure;

public partial class UsersModuleDbContext : DbContext, IDatabaseContext
{
    public UsersModuleDbContext()
    {
    }

    public UsersModuleDbContext(DbContextOptions<UsersModuleDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<Role> Roles { get; set; }

    public Guid TransactionId => throw new NotImplementedException();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3213E83F93B1F8BB");

            entity.ToTable("User");

            entity.HasIndex(e => e.Login, "UQ__User__7838F272EEAE83E7").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdRole).HasColumnName("idRole");
            entity.Property(e => e.Image)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("image");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Login)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Surname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("surname");

            entity.HasOne(d => d.IdRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_Users_Roles");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3213E83FD2A0C535");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Access).HasColumnName("access");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
