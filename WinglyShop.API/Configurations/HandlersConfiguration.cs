using System.Reflection;
using WinglyShop.Application.Abstractions.Messaging;

namespace WinglyShop.API.Configurations;

public static class HandlersConfiguration
{
    public static void AddHandlersFromAssembly(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract)
            .SelectMany(t => t.GetInterfaces(), (type, handlerInterface) => new { type, handlerInterface })
            .Where(t => t.handlerInterface.IsGenericType &&
                       (t.handlerInterface.GetGenericTypeDefinition() == typeof(ICommandHandler<>) ||
                        t.handlerInterface.GetGenericTypeDefinition() == typeof(ICommandHandler<,>) ||
                        t.handlerInterface.GetGenericTypeDefinition() == typeof(IQueryHandler<,>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            services.AddTransient(handlerType.handlerInterface, handlerType.type);
        }
    }
}
