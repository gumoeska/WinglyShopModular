using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Authentication.Application.Queries.Responses;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Authentication.Application.Queries.Profile;

public sealed record GetAuthenticatedProfileQuery(string Login) : IQuery<UserDataResponse>;
