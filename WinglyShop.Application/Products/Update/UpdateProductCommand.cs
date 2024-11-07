using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Products;

namespace WinglyShop.Application.Products.Update;

public sealed record UpdateProductCommand(ProductDTO Product) : ICommand<bool>;
