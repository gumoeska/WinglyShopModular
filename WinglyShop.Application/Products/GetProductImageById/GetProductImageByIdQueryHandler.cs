using Microsoft.EntityFrameworkCore;
using WinglyShop.Application.Abstractions.Data;
using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Application.Abstractions.Storage;
using WinglyShop.Domain.Common.DTOs.Products;
using WinglyShop.Shared;

namespace WinglyShop.Application.Products.GetProductImageById;

internal sealed class GetProductImageByIdQueryHandler : IQueryHandler<GetProductImageByIdQuery, FileResponse>
{
    private readonly IDatabaseContext _context;
    private readonly IFileStorageService _fileStorageService;

    public GetProductImageByIdQueryHandler(
        IDatabaseContext context,
        IFileStorageService fileStorageService)
    {
        _context = context;
        _fileStorageService = fileStorageService;
    }

    public async Task<Result<FileResponse>> Handle(GetProductImageByIdQuery query, CancellationToken cancellationToken)
    {
        // Validation
        if (query is null)
        {
            return Result.Failure<FileResponse>(new Error("Error", "Ocorreu um erro ao buscar a imagem do produto selecionado."));
        }

        // Getting the product by id
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == query.Id);

        // Validate the Product/Category
        if (product is null)
        {
            return Result.Failure<FileResponse>(new Error("Error", "Ocorreu um erro ao buscar o produto selecionado."));
        }

        // Setting the image
        var imagePath = _fileStorageService.GetFilePath(product.ImageUrl);

        return Result.Success(await _fileStorageService.GetFile(imagePath));
    }
}
