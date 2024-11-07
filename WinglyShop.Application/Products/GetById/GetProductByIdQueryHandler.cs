using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Abstractions.Storage;
using WinglyShop.Domain.Common.DTOs.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.GetById;

internal sealed class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, ProductFormDTO>
{
    private readonly IDatabaseContext _context;
    private readonly IFileStorageService _fileStorageService;

    public GetProductByIdQueryHandler(
        IDatabaseContext context, 
        IFileStorageService fileStorageService)
    {
        _context = context;
        _fileStorageService = fileStorageService;
    }

    public async Task<Result<ProductFormDTO>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        // Validation
        if (query is null)
        {
            return Result.Failure<ProductFormDTO>(new Error("Error", "Ocorreu um erro ao buscar o produto selecionado."));
        }

        // Getting the product by id
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        // Finding the Category of the product by id
        var category = await _context.Categories
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == product.IdCategory.GetValueOrDefault(0));

        // Validate the Product/Category
        if (product is null)
        {
            return Result.Failure<ProductFormDTO>(new Error("Error", "Ocorreu um erro ao buscar o produto selecionado."));
        }

        // Setting the description
        if (category is not null)
        {
            product.CategoryDescription = category.Description;
        }

        var productFormDto = new ProductFormDTO(product);

        // Setting the image
        //if (!string.IsNullOrWhiteSpace(product.ImageUrl))
        //{
        //    var imagePath = _fileStorageService.GetFilePath(product.ImageUrl);

        //    productFormDto.Image = await _fileStorageService.GetFile(imagePath);
        //}

        return Result.Success(productFormDto);
    }
}
