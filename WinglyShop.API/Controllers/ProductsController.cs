using Microsoft.AspNetCore.Mvc;
using WinglyShop.API.Abstractions.Auth;
using WinglyShop.API.Abstractions;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Dispatcher;
using WinglyShop.Application.Products;
using WinglyShop.API.Attributes;
using WinglyShop.Domain.Common.Enums.Account;
using WinglyShop.Application.Wishlist;
using Microsoft.AspNetCore.Authorization;
using WinglyShop.Application.Products.Get;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Application.Products.GetById;
using WinglyShop.Application.Products.Update;
using WinglyShop.Application.Products.Delete;
using WinglyShop.Application.Products.UnlinkCategory;
using WinglyShop.Domain.Common.DTOs.Products;
using WinglyShop.Application.Products.GetProductImageById;

namespace WinglyShop.API.Controllers;

[Route("api/[controller]")]
public class ProductsController : ApiController
{
	public ProductsController(
		IDatabaseContext databaseContext,
		IDbConnection dbConnection,
		IDispatcher dispatcher,
		IUserAccessor userAccessor)
		: base(databaseContext, dbConnection, dispatcher, userAccessor)
	{
	}

	[AllowAnonymous]
	[HttpGet]
	public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
	{
		var query = new GetProductListQuery();

		var userRequest = await _dispatcher.Query<GetProductListQuery, List<Product>>(query, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		//return Ok(Result.Success(userRequest.Value));
		return Ok(userRequest.Value);
	}

    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id, CancellationToken cancellationToken)
    {
        var query = new GetProductByIdQuery(id);

        var userRequest = await _dispatcher.Query<GetProductByIdQuery, ProductFormDTO>(query, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [AllowAnonymous]
    [HttpGet("image/{id}")]
    public async Task<IActionResult> GetProductImageById(int id, CancellationToken cancellationToken)
    {
        var query = new GetProductImageByIdQuery(id);

        var userRequest = await _dispatcher.Query<GetProductImageByIdQuery, FileResponse>(query, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return File(userRequest.Value.Stream, userRequest.Value.ContentType, userRequest.Value.FileName);
    }

    [AllowAnonymous]
    [HttpGet("GetByCategory/{id}")]
    public async Task<IActionResult> GetProductByCategoryId(int id, CancellationToken cancellationToken)
    {
        var query = new GetProductByCategoryIdQuery(id);

        var userRequest = await _dispatcher.Query<GetProductByCategoryIdQuery, List<Product>>(query, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
	[HttpPost("Create")]
	public async Task<IActionResult> CreateProduct([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
	{
		var command = new CreateProductCommand(request);

		var userRequest = await _dispatcher.Send<CreateProductCommand, bool>(command, cancellationToken);

		if (userRequest is { IsFailure: true })
		{
			return BadRequest(userRequest.Error);
		}

		//return Ok(Result.Success(userRequest.Value));
		return Ok(userRequest.Value);
	}

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpPost("Update")]
    public async Task<IActionResult> UpdateProduct(UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var productDto = new ProductDTO
        {
            Id = request.Id,
            Code = request.Code,
            Description = request.Description,
            Price = request.Price,
            HasStock = request.HasStock,
            IsActive = request.IsActive,
            IdCategory = request.IdCategory
        };

        var command = new UpdateProductCommand(productDto);

        var userRequest = await _dispatcher.Send<UpdateProductCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        //return Ok(Result.Success(userRequest.Value));
        return Ok(userRequest.Value);
    }

    [AuthAccessLevel(RoleAccess.GeneralManager)]
    [HttpPatch("UnlinkCategory/{id}")]
    public async Task<IActionResult> UnlinkCategoryProducts(int id, CancellationToken cancellationToken)
    {
        var command = new UnlinkCategoryCommand(id);

        var userRequest = await _dispatcher.Send<UnlinkCategoryCommand, bool>(command, cancellationToken);

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
        var command = new DeleteProductCommand(id);

        var userRequest = await _dispatcher.Send<DeleteProductCommand, bool>(command, cancellationToken);

        if (userRequest is { IsFailure: true })
        {
            return BadRequest(userRequest.Error);
        }

        //return Ok(Result.Success(userRequest.Value));
        return Ok(userRequest.Value);
    }

    [HttpPost("cart/{productId}/add")]
	public async Task<IActionResult> UserAddProductToCart([FromBody] CreateProductRequest request, CancellationToken cancellationToken)
	{
		// receber o id do produto e o usuário da requisição
		return Ok();
	}

	[HttpDelete("cart/{productId}/remove")]
	public async Task<IActionResult> UserRemoveProductFromCart(CreateProductRequest request, CancellationToken cancellationToken)
	{
		return Ok();
	}

    [HttpPost("wishlist/{productId}/add")]
    public async Task<IActionResult> UserAddProductToWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }

    [HttpDelete("wishlist/{productId}/remove")]
    public async Task<IActionResult> UserRemoveProductFromWishlist([FromBody] AddProductWishlistRequest request, CancellationToken cancellationToken)
    {
        return Ok();
    }
}
