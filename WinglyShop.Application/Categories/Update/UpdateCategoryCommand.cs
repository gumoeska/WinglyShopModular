using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Categories;

namespace WinglyShop.Application.Categories.Update;

public sealed record UpdateCategoryCommand(int Id, string Code, string Description, bool IsActive) : ICommand<bool>;
