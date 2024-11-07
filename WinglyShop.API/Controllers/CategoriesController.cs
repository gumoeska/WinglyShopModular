using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Attributes;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Categories;
using WinglyShop.Application.Categories.Delete;
using WinglyShop.Application.Categories.Get;
using WinglyShop.Application.Categories.GetById;
using WinglyShop.Application.Categories.Update;
using WinglyShop.Domain.Common.DTOs.Categories;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Shared;

namespace WinglyShop.API.Controllers;

[Authorize]
[Route("api/[controller]")]
public class CategoriesController : ApiController
{
    public CategoriesController(
        IDatabaseContext databaseContext,
        IDbConnection dbConnection,
        IDispatcher dispatcher,
        IUserAccessor userAccessor)
        : base(databaseContext, dbConnection, dispatcher, userAccessor)
    {
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories(CancellationToken cancellationToken)
    {
        var query = new GetCategoryListQuery();

        var userRequest = await _dispatcher.Query<GetCategoryListQuery, List<Category>>(query, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        //return Ok(Result.Success(userRequest.Value));
        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategoryById(int id, CancellationToken cancellationToken)
    {
        var query = new GetCategoryByIdQuery(id);

        var userRequest = await _dispatcher.Query<GetCategoryByIdQuery, Category>(query, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpPost("Create")]
    public async Task<IActionResult> CreateCategory(CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var categoryDto = new CategoryDTO(
            request.Code,
            request.Description,
            request.IsActive);

        var command = new CreateCategoryCommand(categoryDto);

        var userRequest = await _dispatcher.Send<CreateCategoryCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateCategoryCommand(
            request.Id,
            request.Code,
            request.Description,
            request.IsActive);

        var userRequest = await _dispatcher.Send<UpdateCategoryCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpDelete("Delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteCategoryCommand(id);

        var userRequest = await _dispatcher.Send<DeleteCategoryCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }
}
