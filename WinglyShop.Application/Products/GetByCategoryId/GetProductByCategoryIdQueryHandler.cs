using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.GetById;

internal sealed class GetProductByCategoryIdQueryHandler : IQueryHandler<GetProductByCategoryIdQuery, List<Product>>
{
    private readonly IDatabaseContext _context;

    public GetProductByCategoryIdQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Product>>> Handle(GetProductByCategoryIdQuery query, CancellationToken cancellationToken)
    {
        // Validation
        if (query is null)
        {
            return Result.Failure<List<Product>>(new Error("Error", "Ocorreu um erro ao buscar a lista de produtos da categoria."));
        }

        // Getting the products by the category id
        var productList = await _context.Products
            .AsNoTracking()
            .Where(x => x.IdCategory == query.CategoryId)
            .ToListAsync();

        return Result.Success(productList);
    }
}
