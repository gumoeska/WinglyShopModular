namespace WinglyShop.API.Extensions.Authorization;

public sealed class AuthorizationModelResponse
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? AuthData { get; set; }
}
