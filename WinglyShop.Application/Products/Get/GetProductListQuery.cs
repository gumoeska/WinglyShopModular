using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Application.Products.Get;

public sealed record GetProductListQuery() : IQuery<List<Product>>;
