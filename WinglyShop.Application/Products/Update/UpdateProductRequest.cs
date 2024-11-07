namespace WinglyShop.Application.Products.Update;

public sealed record UpdateProductRequest(
    int Id,
    string Code,
    string Description,
    decimal Price,
    bool HasStock,
    bool IsActive,
    int IdCategory);
