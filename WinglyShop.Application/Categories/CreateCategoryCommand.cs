using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Categories;

namespace WinglyShop.Application.Categories;

public sealed record CreateCategoryCommand(CategoryDTO category) : ICommand<bool>;
