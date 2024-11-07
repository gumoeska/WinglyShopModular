using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Common.DTOs.Products;

public sealed class ProductDTO
{
    public ProductDTO()
    {
    }

    public ProductDTO(Product product)
    {
        Id = product.Id;
        Code = product.Code;
        Description = product.Description;
        Price = product.Price;
        ImageUrl = product.ImageUrl;
        HasStock = product.HasStock;
        IsActive = product.IsActive;
        IdCategory = product.IdCategory;
    }

    public int Id { get; set; }
    public string? Code { get; set; }
    public string? Description { get; set; }
    public decimal? Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool? HasStock { get; set; }
    public bool? IsActive { get; set; }
    public int? IdCategory { get; set; }
}
