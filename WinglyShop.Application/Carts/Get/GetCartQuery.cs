using WinglyShop.Domain.Entities.Carts;
using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.Application.Carts.Get;

public sealed record GetCartQuery(int CartId) : IQuery<Cart?>;
