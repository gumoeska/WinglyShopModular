using WinglyShop.Infrastructure.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Infrastructure.Abstractions.Dispatcher;

public interface IDispatcher
{
	Task Send<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
	Task<Result<TResponse>> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand<TResponse>;

	Task<Result<TResponse>> Query<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TResponse>;
}
