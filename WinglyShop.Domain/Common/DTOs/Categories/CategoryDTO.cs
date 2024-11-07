namespace WinglyShop.Domain.Common.DTOs.Categories;

public sealed record CategoryDTO(
	string Code,
	string Description,
	bool IsActive);
