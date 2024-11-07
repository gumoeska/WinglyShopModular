using System.ComponentModel;

namespace WinglyShop.Domain.Common.Enums.Payment;

public enum PaymentMethod
{
	[Description("Cash")]
	Cash = 0,

	[Description("Debit Card")]
	DebitCard = 1,

	[Description("Credit Card")]
	CreditCard = 2,

	[Description("Bank Slip")]
	BankSlip = 3, // Boleto Bancário

	[Description("PIX")]
	PIX = 4,

	[Description("PayPal")]
	PayPal = 5
}
