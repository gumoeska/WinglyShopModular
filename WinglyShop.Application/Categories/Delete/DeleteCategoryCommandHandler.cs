using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Application.Categories.Delete;

internal sealed class DeleteCategoryCommandHandler : ICommandHandler<DeleteCategoryCommand, bool>
{
	private readonly IDatabaseContext _context;

    public DeleteCategoryCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
			throw new ArgumentNullException(nameof(command));
		}

        var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (category is null)
        {
            return Result.Failure<bool>(new Error("Error", "A categoria não foi encontrada."));
        }

        // Check if exist Products with the category
        var productsWithCategory = await _context.Products
            .AsNoTracking()
            .Where(x => x.IdCategory == command.Id)
            .ToListAsync();

        if (!productsWithCategory.IsNullOrEmpty()) 
        {
            return Result.Failure<bool>(new Error("Error", "Existem produtos vinculados a esta categoria."));
        }

        try
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao deletar a Categoria."));
		}

        return Result.Success(true);
	}
}
