using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Categories.Delete;

public sealed record DeleteCategoryCommand(int Id) : ICommand<bool>;
