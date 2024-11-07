using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.Get;

internal sealed class GetProductListQueryHandler : IQueryHandler<GetProductListQuery, List<Product>>
{
    private readonly IDatabaseContext _context;

    public GetProductListQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<List<Product>>> Handle(GetProductListQuery query, CancellationToken cancellationToken)
    {
        // Todo: implementar paginação (trazer valores da Query) {skip - take}

        // Product List
        var productList = await _context.Products.AsNoTracking().ToListAsync();

        // Getting the Id's of registered products
        var listCategoryId = productList
            .Distinct()
            .Where(x => x.IdCategory > 0)
            .Select(x => x.IdCategory)
            .ToList();

        // Finding the Categories by id
        var categoriesList = await _context.Categories
            .AsNoTracking()
            .Where(x => listCategoryId.Contains(x.Id))
            .ToListAsync();

        // Setting the descriptions
        productList.ForEach(item =>
        {
            if (item.IdCategory is null)
            {
                return;
            }

            item.CategoryDescription = categoriesList
                .Where(x => x.Id == item.IdCategory)
                .Select(x => x.Description)
                .FirstOrDefault();
        });

        if (productList.IsNullOrEmpty())
        {
            // If there is not products, return an empty list of products
            productList = new List<Product>();
            //return Result.Failure<List<Product>>(new Error("Error", "Ocorreu um erro."));
        }

        return Result.Success(productList);
    }
}
