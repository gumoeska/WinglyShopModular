using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Attributes;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Authentication.Profile.Response;
using WinglyShop.Application.Authentication.Profile;
using WinglyShop.Application.Users.Delete;
using WinglyShop.Application.Users.Get;
using WinglyShop.Application.Users.GetById;
using WinglyShop.Application.Users.SetAccess;
using WinglyShop.Application.Users.Update;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Users;
using WinglyShop.Shared;
using WinglyShop.Application.Users.DTOs;
using WinglyShop.Application.Users.GetUserProfile;
using WinglyShop.Application.Profile.Update.Profile;
using WinglyShop.Application.Profile.Update.Account;

namespace WinglyShop.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class ProfileController : ApiController
{
	public ProfileController(
		IDatabaseContext databaseContext,
		IDbConnection dbConnection,
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
	}

    [HttpPut("Update-Profile")]
	public async Task<IActionResult> UpdateUserProfile([FromBody] UpdateUserProfileRequest request, CancellationToken cancellationToken)
	{
        // Getting the username
        var username = _userAccessor.GetCurrentUsername();

        // Creating the command
        var command = new UpdateUserProfileCommand(request, username);

        // Sending the request
        var userRequest = await _dispatcher.Send<UpdateUserProfileCommand, bool>(command, cancellationToken);

        // Validating the request
        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [HttpPut("Update-Account")]
    public async Task<IActionResult> UpdateUserAccount([FromBody] UpdateUserAccountRequest request, CancellationToken cancellationToken)
    {
        // Getting the username
        var username = _userAccessor.GetCurrentUsername();

        // Creating the command
        var command = new UpdateUserAccountCommand(request, username);

        // Sending the request
        var userRequest = await _dispatcher.Send<UpdateUserAccountCommand, bool>(command, cancellationToken);

        // Validating the request
        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [HttpDelete("Delete")]
	public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}
}

