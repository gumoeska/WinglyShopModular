using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;
using WinglyShop.Domain.Common.DTOs.Products;
using WinglyShop.Domain.Entities.CartDetails;
using WinglyShop.Domain.Entities.Categories;
using WinglyShop.Domain.Entities.OrderDetails;

namespace WinglyShop.Domain.Entities.Products;

public partial class Product
{
    public Product()
    {
    }

    public Product(ProductDTO product)
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

    [NotMapped]
    public string? CategoryDescription { get; set; }

    public virtual ICollection<CartDetail> CartDetails { get; set; } = new List<CartDetail>();

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
