namespace WinglyShop.Application.Products.GetProductImageById;

public sealed record FileResponse(Stream Stream, string ContentType, string FileName);
