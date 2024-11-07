using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Products;

namespace WinglyShop.Application.Products.UnlinkCategory;

public sealed record UnlinkCategoryCommand(int Id) : ICommand<bool>;
