using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Shared;

namespace WinglyShop.Application.Categories;

internal sealed class CreateCategoryCommandHandler : ICommandHandler<CreateCategoryCommand, bool>
{
	private readonly IDatabaseContext _context;

    public CreateCategoryCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

	public async Task<Result<bool>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        var category = new Category(command.category);

        try
        {
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "An error occured."));
        }

        return Result.Success(true);
	}
}
