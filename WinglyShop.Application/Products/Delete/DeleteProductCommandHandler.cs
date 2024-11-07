using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.Delete;

internal sealed class DeleteProductCommandHandler : ICommandHandler<DeleteProductCommand, bool>
{
	private readonly IDatabaseContext _context;

    public DeleteProductCommandHandler(IDatabaseContext context)
    {
        _context = context;
    }

    public async Task<Result<bool>> Handle(DeleteProductCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
			throw new ArgumentNullException(nameof(command));
		}

        var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == command.Id);

        if (product is null)
        {
            return Result.Failure<bool>(new Error("Error", "O produto não foi encontrado."));
        }

        try
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "Ocorreu um erro ao deletar o Produto."));
		}

        return Result.Success(true);
	}
}
