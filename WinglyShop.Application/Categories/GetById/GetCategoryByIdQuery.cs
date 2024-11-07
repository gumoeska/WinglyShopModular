using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Categories;

namespace WinglyShop.Application.Categories.GetById;

public sealed record GetCategoryByIdQuery(int Id) : IQuery<Category>;
