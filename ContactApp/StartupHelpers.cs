using DataLayer.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.SeedingServices;

namespace ContactApp;

/// <summary>
/// Extension methods for app startup
/// </summary>
public static class StartupHelpers
{
    /// <summary>
    /// Ensure database is at the newest migration and is seeded
    /// </summary>
    public static async Task<IHost> SetupDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<AppDbContext>();

        try
        {
            var arePendingMigrations = (await context.Database.GetPendingMigrationsAsync()).Any();
            await context.Database.MigrateAsync();
            if (arePendingMigrations)
            {
                await context.SeedDatabaseIfNoContacts();
            }
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occured while creating/migrating or seeding the database");
            throw;
        }

        return host;
    }
}
