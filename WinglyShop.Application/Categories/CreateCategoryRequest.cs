using WinglyShop.Domain.Common.DTOs.Categories;

namespace WinglyShop.Application.Categories;

public sealed record CreateCategoryRequest(
    string Code,
    string Description,
    bool IsActive);
