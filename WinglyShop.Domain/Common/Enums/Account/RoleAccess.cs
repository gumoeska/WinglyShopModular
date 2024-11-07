using System.ComponentModel;

namespace WinglyShop.Domain.Common.Enums.Account;

public enum RoleAccess
{ 
	[Description("Cliente")] //[Description("Customer")]
    Customer = 0,

	[Description("Cliente Premium")] //[Description("Premium Customer")]
	PremiumCustomer = 1,

	[Description("Atendente")] //[Description("Attendant")]
	Attendant = 2,

	[Description("Suporte")] //[Description("Support")]
	Support = 3,

	[Description("Suporte Técnico")] //[Description("Technical Support")]
	TechnicalSupport = 4,

	[Description("Gerente")] //[Description("Manager")]
	Manager = 5,

	[Description("Gerente Geral")] //[Description("General Manager")]
	GeneralManager = 6,

	[Description("Desenvolvedor")] //[Description("Developer")]
	Developer = 7,

	// Master Access
	[Description("Administrador")] //[Description("Admin")]
	Admin = 100
}
