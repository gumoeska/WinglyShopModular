using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Profile.Update.Profile;

public sealed record UpdateUserProfileCommand(UpdateUserProfileRequest Request, string Username) : ICommand<bool>;
