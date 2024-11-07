using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Application.Products.GetById;

public sealed record GetProductByCategoryIdQuery(int CategoryId) : IQuery<List<Product>>;
