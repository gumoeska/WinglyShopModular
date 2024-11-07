namespace WinglyShop.Application.Categories.Update;

public sealed record UpdateCategoryRequest(int Id, string Code, string Description, bool IsActive);
