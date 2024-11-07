using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Abstractions.Storage;
using WinglyShop.Domain.Common.DTOs.Products;
using WinglyShop.Domain.Entities.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products;

internal sealed class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, bool>
{
	private readonly IDatabaseContext _context;
    private readonly IFileStorageService _fileStorageService;

    public CreateProductCommandHandler(
        IDatabaseContext context, 
        IFileStorageService fileStorageService)
    {
        _context = context;
        _fileStorageService = fileStorageService;
    }

    public async Task<Result<bool>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
	{
        if (command is null)
        {
			throw new ArgumentNullException(nameof(command));
        }

        // Building the DTO
        var productDto = new ProductDTO
        {
            Code = command.Product.Code,
            Description = command.Product.Description,
            Price = command.Product.Price,
            HasStock = command.Product.HasStock,
            IsActive = command.Product.IsActive,
            IdCategory = command.Product.IdCategory
        };

        // Saving the image file (if exists)
        var fileName = string.Empty;

        if (command.Product.Image is not null || command?.Product?.Image?.Length > 0)
        {
            fileName = await _fileStorageService.SaveFileAsync(command.Product.Image);

            productDto.ImageUrl = fileName;
        }

        var product = new Product(productDto);

        try
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            return Result.Failure<bool>(new Error("Error", "An error occured."));
		}

        return Result.Success(true);
	}
}
