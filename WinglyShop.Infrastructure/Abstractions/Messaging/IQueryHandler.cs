using WinglyShop.Shared;

namespace WinglyShop.Infrastructure.Abstractions.Messaging;

public interface IQueryHandler<in TQuery, TResponse>
	where TQuery : IQuery<TResponse>
{
	Task<Result<TResponse>> Handle(TQuery query, CancellationToken cancellationToken);
}
