using WinglyShop.Domain.Common.Interfaces;

namespace WinglyShop.Domain.Common;

public class BaseEntity : IEntity
{
	//public Guid Id { get; set; }
	public int Id { get; set; }
	public bool IsActive { get; set; }
}
