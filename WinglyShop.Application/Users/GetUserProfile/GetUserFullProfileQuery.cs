using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Application.Users.DTOs;
using WinglyShop.Domain.Entities.Users;

namespace WinglyShop.Application.Users.GetUserProfile;

public sealed record GetUserFullProfileQuery(string Login) : IQuery<UserFullProfileDTO>;
