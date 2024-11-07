using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Products;

namespace WinglyShop.Application.Products.GetById;

public sealed record GetProductByIdQuery(int Id) : IQuery<ProductFormDTO>;
