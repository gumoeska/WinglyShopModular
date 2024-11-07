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

namespace WinglyShop.API.Controllers.Modules.Users;

[Authorize]
[Route("api/[controller]")]
public class UsersController : ApiController
{
    public UsersController(
        IDatabaseContext databaseContext,
        IDbConnection dbConnection,
        IDispatcher dispatcher,
        IUserAccessor userAccessor)
        : base(databaseContext, dbConnection, dispatcher, userAccessor)
    {
    }

    [HttpGet]
    //[Authorize(Roles = nameof(RoleAccess.Admin))]
    [AuthAccessLevel(RoleAccess.Manager)]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        // Creating the query
        var query = new GetUsersQuery();

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetUsersQuery, List<User>>(query, cancellationToken);

        // Validate the response
        if (userRequest is { IsFailure: true })
            return BadRequest(userRequest.Error);

        //return Ok(Result.Success(userRequest.Value));
        return Ok(userRequest.Value);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUserById([FromBody] GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        // Creating the query
        var query = new GetUserByIdQuery(request.userId);

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetUserByIdQuery, User?>(query, cancellationToken);

        // Validate the request
        if (userRequest is { IsFailure: true })
            return BadRequest(userRequest.Error);

        // Get the User
        var userResponse = userRequest.Value;

        // Validate the userResponse
        if (userResponse is null)
            return BadRequest(userResponse);

        return Ok(Result.Success<User?>(userResponse));
    }

    [Authorize]
    [HttpGet("full-profile")]
    public async Task<IActionResult> GetAuthenticatedProfile(CancellationToken cancellationToken)
    {
        // Getting the username
        var username = _userAccessor.GetCurrentUsername();

        // Validate if the username (token) is null
        if (username is null)
        {
            return BadRequest("Você precisa estar logado.");
        }

        // Creating the query
        var query = new GetUserFullProfileQuery(username);

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetUserFullProfileQuery, UserFullProfileDTO>(query, cancellationToken);

        // Validate the request
        if (userRequest is { IsFailure: true })
            return BadRequest(userRequest.Error);

        return Ok(userRequest.Value);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpPatch("AccessLevel")]
    [AuthAccessLevel(RoleAccess.Admin)]
    public async Task<IActionResult> SetUserAccess([FromBody] SetUserAccessLevelRequest request, CancellationToken cancellationToken)
    {
        // Creating the command
        var command = new SetUserAccessLevelCommand(request.UserId, request.AccessLevel);

        var userRequest = await _dispatcher.Send<SetUserAccessLevelCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(Result.Success(userRequest.Value));
    }
}

