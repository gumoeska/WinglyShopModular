using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Attributes;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Roles;
using WinglyShop.Application.Roles.Get;
using WinglyShop.Application.Roles.GetByAccessLevel;
using WinglyShop.Application.Roles.GetById;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Roles;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[AuthAccessLevel(RoleAccess.Admin)]
[Route("api/[controller]")]
public class RolesController : ApiController
{
    public RolesController(
		IDatabaseContext databaseContext, 
		IDbConnection dbConnection, 
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
        : base(databaseContext, dbConnection, dispatcher, userAccessor)
    {
    }

	[HttpGet]
	public async Task<IActionResult> GetRoles(CancellationToken cancellationToken)
	{
        // Creating the query
        var query = new GetRolesQuery();

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetRolesQuery, List<Role>>(query, cancellationToken);

        // Validate the response
        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        // Send response
        return Ok(Result.Success(userRequest.Value));
    }

    [HttpGet("GetRoleById")]
    public async Task<IActionResult> GetRoleById(GetRoleByIdRequest request, CancellationToken cancellationToken)
    {
        // Creating the query
        var query = new GetRoleByIdQuery(request.RoleId);

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetRoleByIdQuery, Role>(query, cancellationToken);

        // Validate the response
        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        // Send response
        return Ok(Result.Success(userRequest.Value));
    }

    [HttpGet("GetRoleByAccessLevel")]
    public async Task<IActionResult> GetRoleByAccessLevel(GetRoleByAccessLevelRequest request, CancellationToken cancellationToken)
	{
        // Creating the query
        var query = new GetRoleByAccessLevelQuery(request.AccessLevel);

        // Sending the request to the handler
        var userRequest = await _dispatcher.Query<GetRoleByAccessLevelQuery, Role>(query, cancellationToken);

        // Validate the response
        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        // Send response
        return Ok(Result.Success(userRequest.Value));
    }

    [HttpPost("Create")]
    public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
    {
        // Creating the command
        var command = new CreateRoleCommand(request.role);

		// Sending the request to the handler
		var userRequest = await _dispatcher.Send<CreateRoleCommand, bool>(command, cancellationToken);

		// Get the result
		var userResponse = userRequest.Value;

		// Validate the response
		if (userResponse is false)
		{
			return BadRequest(userResponse);
		}

		// Send response
		return Ok(Result.Success<bool>(userResponse));
	}

	[HttpPut("Update")]
    public async Task<IActionResult> UpdateRole()
	{
        return Ok();

    }

    [HttpDelete("Delete")]
    public async Task<IActionResult> DeleteRole()
	{
        return Ok();

    }
}
