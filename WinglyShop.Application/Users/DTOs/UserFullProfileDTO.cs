namespace WinglyShop.Application.Users.DTOs;

public sealed class UserFullProfileDTO
{
    public int Id { get; set; }
    public string? Login { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Image { get; set; }
    public string? Phone { get; set; }
    public string? RoleDescription { get; set; }
    public bool? IsActive { get; set; }
}
