using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Products.Delete;

public sealed record DeleteProductCommand(int Id) : ICommand<bool>;
