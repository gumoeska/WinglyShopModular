using Microsoft.EntityFrameworkCore;
using System;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Application.Extensions;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Shared;

namespace WinglyShop.Application.Authentication.Profile;

internal sealed class GetAuthenticatedProfileQueryHandler : IQueryHandler<GetAuthenticatedProfileQuery, UserDataResponse>
{
    private readonly IDatabaseContext _context;

    public GetAuthenticatedProfileQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<UserDataResponse>> Handle(GetAuthenticatedProfileQuery query, CancellationToken cancellationToken)
	{
        // Validate
        if (query is null)
        {
            return Result.Failure<UserDataResponse>(new Error("Error", "Error"));
        }

        // Getting the user information
        var user = await _context.Users
            .Where(x => x.Login == query.Login)
            .FirstOrDefaultAsync();

        // Validate if the user data exists
        if (user is null)
        {
            return Result.Failure<UserDataResponse>(new Error("Error", "User data not found."));
        }

        // Get the user role
        var userRoleName = await _context.Roles
            .Where(x => x.Id == user.IdRole)
            .Select(x => x.Access)
            .FirstOrDefaultAsync();

        // Building the response
        var userResponse = new UserDataResponse(
            user.Name, 
            user.Surname, 
            user.Email, 
            user.Image,
            userRoleName.DescriptionAttr());

		return Result.Success(userResponse);
	}
}
