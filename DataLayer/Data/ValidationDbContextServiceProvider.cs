using Microsoft.EntityFrameworkCore;

namespace DataLayer.Data;

/// <summary>
/// Service provider that only provides one service: the database context
/// </summary>
/// <remarks>
/// Used for object validation
/// </remarks>
internal class ValidationDbContextServiceProvider(DbContext context) : IServiceProvider
{
    public object? GetService(Type serviceType)
    {
        if (serviceType == typeof(DbContext))
        {
            return context;
        }

        return null;
    }
}
