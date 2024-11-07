using System;
using System.Collections.Generic;
using WinglyShop.Domain.Common.DTOs.Categories;
using WinglyShop.Domain.Entities.Products;

namespace WinglyShop.Domain.Entities.Categories;

public partial class Category
{
    public Category()
    {
    }

    public Category(CategoryDTO categoryDto)
    {
        Code = categoryDto.Code;
        Description = categoryDto.Description;
        IsActive = categoryDto.IsActive;
    }

    public Category(int id, string code, string description, bool isActive)
    {
        Id = id;
        Code = code;
        Description = description;
        IsActive = isActive;
    }

    public int Id { get; set; }

    public string? Code { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    public Category CreateCategory(CategoryDTO categoryDTO)
    {
        var category = new Category();

		category.Code = categoryDTO.Code;
		category.Description = categoryDTO.Description;
		category.IsActive = categoryDTO.IsActive;

        return category;
	}
}
