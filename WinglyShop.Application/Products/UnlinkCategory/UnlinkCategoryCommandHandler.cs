using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Products.UnlinkCategory;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.UnlinkCategory;

internal sealed class UnlinkCategoryCommandHandler : ICommandHandler<UnlinkCategoryCommand, bool>
{
    private readonly IDatabaseContext _context;

    public UnlinkCategoryCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(UnlinkCategoryCommand command, CancellationToken cancellationToken)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var productsWithSelectedCategory = await _context.Products
            .Where(x => x.IdCategory == command.Id)
            .ToListAsync();

        if (productsWithSelectedCategory.IsNullOrEmpty())
        {
            return Result.Failure<bool>(new Error("Error", "Nenhum produto encontrado para esta categoria."));
        }

        try
        {
            productsWithSelectedCategory.ForEach(x => x.IdCategory = null); // 0 - Default - "No Category"

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao atualizar as informações do Produto."));
        }

        return Result.Success(true);
    }
}
