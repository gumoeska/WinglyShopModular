using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Shared;

namespace WinglyShop.Application.Categories.Update;

internal sealed class UpdateCategoryCommandHandler : ICommandHandler<UpdateCategoryCommand, bool>
{
	private readonly IDatabaseContext _context;

    public UpdateCategoryCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

	public async Task<Result<bool>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var category = new Category(
            command.Id, 
            command.Code, 
            command.Description,
            command.IsActive);

        try
        {
            var categoryToEdit = await _context.Categories
                .Where(x => x.Id == category.Id)
                .FirstOrDefaultAsync();

            if (category is not null)
            {
                categoryToEdit.Code = category.Code;
                categoryToEdit.Description = category.Description;
                categoryToEdit.IsActive = category.IsActive;
            }


            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao atualizar as informações da Categoria."));
        }

        return Result.Success(true);
	}
}
