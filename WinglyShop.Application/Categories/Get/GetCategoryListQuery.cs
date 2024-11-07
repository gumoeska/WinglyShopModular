using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Categories;

namespace WinglyShop.Application.Categories.Get;

public sealed record GetCategoryListQuery() : IQuery<List<Category>>;
