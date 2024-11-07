using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Products;

public sealed record CreateProductCommand(CreateProductRequest Product) : ICommand<bool>;
