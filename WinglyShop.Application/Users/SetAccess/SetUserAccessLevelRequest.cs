namespace WinglyShop.Application.Users.SetAccess;

public sealed record SetUserAccessLevelRequest(int UserId, int AccessLevel);
