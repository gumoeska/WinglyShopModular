using WinglyShop.Application.Abstractions.Messaging;
using WinglyShop.Shared;

namespace WinglyShop.Infrastructure.Abstractions.Dispatcher;

public class Dispatcher : IDispatcher
{
	private readonly IServiceProvider _serviceProvider;

	public Dispatcher(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task Send<TCommand>(TCommand command, CancellationToken cancellationToken)
		where TCommand : ICommand
	{
		var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand>)) as ICommandHandler<TCommand>;

		if (handler is null)
			throw new InvalidOperationException($"Handler not found. Command: '{typeof(TCommand)}'.");

		await handler.Handle(command, cancellationToken);
	}

	public async Task<Result<TResponse>> Send<TCommand, TResponse>(TCommand command, CancellationToken cancellationToken)
		where TCommand : ICommand<TResponse>
	{
		var handler = _serviceProvider.GetService(typeof(ICommandHandler<TCommand, TResponse>)) as ICommandHandler<TCommand, TResponse>;

		if (handler is null)
			throw new InvalidOperationException($"Handler not found. Command: '{typeof(TCommand)}'.");

		return await handler.Handle(command, cancellationToken);
	}

	public async Task<Result<TResponse>> Query<TQuery, TResponse>(TQuery query, CancellationToken cancellationToken)
		where TQuery : IQuery<TResponse>
	{
		var handler = _serviceProvider.GetService(typeof(IQueryHandler<TQuery, TResponse>)) as IQueryHandler<TQuery, TResponse>;

		if (handler is null)
			throw new InvalidOperationException($"Handler not found. Query: '{typeof(TQuery)}'.");

		return await handler.Handle(query, cancellationToken);
	}
}
