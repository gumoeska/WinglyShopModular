using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Authentication.Profile;

public sealed record GetAuthenticatedProfileQuery(string Login) : IQuery<UserDataResponse>;
