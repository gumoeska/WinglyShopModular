using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Domain.Common.DTOs.Products;

namespace WinglyShop.Application.Products.GetProductImageById;

public sealed record GetProductImageByIdQuery(int Id) : IQuery<FileResponse>;
