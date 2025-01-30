using Microsoft.Extensions.DependencyInjection;

namespace InfrastructureLayer;

/// <summary>
/// Extension methods for registering infrastructure services from the layer
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register infrastructure services from the layer
    /// </summary>
    /// <param name="services">Service collection</param>
    public static void RegisterInfrastructureLayerDi(this IServiceCollection services)
    {
        var businessServices =
            from type in typeof(ServiceCollectionExtensions).Assembly.DefinedTypes
            let implementedService = type.ImplementedInterfaces
                .FirstOrDefault(IsInfrastructureServiceInterface)
            where implementedService is not null
            select (Interface: implementedService, Implementation: type);

        foreach (var service in businessServices)
        {
            services.AddTransient(service.Interface, service.Implementation);
        }
    }

    /// <summary>
    /// Determine whether the given type (supposed to be an interface) is a infrastructure service
    /// interface
    /// </summary>
    /// <param name="type">The type to check. Supposed to be an interface</param>
    private static bool IsInfrastructureServiceInterface(Type type) =>
        type.IsAssignableTo(typeof(IInfrastructureService)) && type != typeof(IInfrastructureService);
}
