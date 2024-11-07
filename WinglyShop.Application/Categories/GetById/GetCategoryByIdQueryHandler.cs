using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Categories.GetById;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Shared;
using WinglyShop.Shared.Extensions;

namespace WinglyShop.Application.Categories.Get;

internal sealed class GetCategoryByIdQueryHandler : IQueryHandler<GetCategoryByIdQuery, Category>
{
    private readonly IDatabaseContext _context;

    public GetCategoryByIdQueryHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<Category>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        if (query is null)
        {
            return Result.Failure<Category>(new Error("Error", "Ocorreu um erro ao buscar a categoria."));
        }

        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        if (category is null)
        {
            return Result.Failure<Category>(new Error("Error", "Categoria não encontrada."));
        }

        return Result.Success(category);
    }
}
