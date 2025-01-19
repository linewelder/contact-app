using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.ContactServices;

namespace ServiceLayer;

/// <summary>
/// Extension methods for registering business services from the layer
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Register business services from the layer
    /// </summary>
    /// <param name="services">Service collection</param>
    public static void RegisterServiceLayerDi(this IServiceCollection services)
    {
        var businessServices =
            from type in typeof(ServiceCollectionExtensions).Assembly.DefinedTypes
            let implementedService = type.ImplementedInterfaces
                .FirstOrDefault(IsBusinessServiceInterface)
            where implementedService is not null
            select (Interface: implementedService, Implementation: type);

        foreach (var service in businessServices)
        {
            services.AddTransient(service.Interface, service.Implementation);
        }
    }

    /// <summary>
    /// Determine whether the given type (supposed to be an interface) is a business service
    /// interface
    /// </summary>
    /// <param name="type">The type to check. Supposed to be an interface</param>
    private static bool IsBusinessServiceInterface(Type type) =>
        type.IsAssignableTo(typeof(IBusinessService)) && type != typeof(IBusinessService);
}
