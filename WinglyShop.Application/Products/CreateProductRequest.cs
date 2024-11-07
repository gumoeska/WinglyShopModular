using Azure.Core;
using Microsoft.AspNetCore.Http;
using WinglyShop.Domain.Entities.Categories;

namespace WinglyShop.Application.Products;

public sealed record CreateProductRequest(
    string Code,
    string Description,
    decimal Price,
    bool HasStock,
    bool IsActive,
    int IdCategory,
    IFormFile? Image);
