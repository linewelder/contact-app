using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Data;

/// <summary>
/// Extension methods for DbContext
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Validate the updated entries and save changes if validation successful
    /// </summary>
    public static async ValueTask<ImmutableList<ValidationResult>> SaveChangesWithValidationAsync(
        this DbContext context)
    {
        var result = context.ExecuteValidation();
        if (!result.IsEmpty) return result;

        // ExecuteValidation has already called DetectChanges indirectly
        context.ChangeTracker.AutoDetectChangesEnabled = false;
        try
        {
            await context.SaveChangesAsync();
        }
        finally
        {
            context.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        return result;
    }

    /// <summary>
    /// Validate updated entries
    /// </summary>
    private static ImmutableList<ValidationResult> ExecuteValidation(
        this DbContext context)
    {
        var result = new List<ValidationResult>();

        var needValidation = context.ChangeTracker.Entries()
            .Where(e => e.State is EntityState.Added or EntityState.Modified);
        foreach (var entry in needValidation)
        {
            var entity = entry.Entity;
            var serviceProvider = new ValidationDbContextServiceProvider(context);
            var valContext = new ValidationContext(entity, serviceProvider, null);
            var entityErrors = new List<ValidationResult>();
            if (!Validator.TryValidateObject(entity, valContext, entityErrors, true))
            {
                result.AddRange(entityErrors);
            }
        }

        return result.ToImmutableList();
    }
}
