using DataLayer.Data;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.SeedingServices;

/// <summary>
/// Helper methods for database seeding
/// </summary>
public static class StartupHelpers
{
    private const string SeedFilePath = "seedData.json";

    public static async Task<int> SeedDatabaseIfNoContacts(this AppDbContext context)
    {
        var numberOfContacts = await context.Contacts.CountAsync();
        if (numberOfContacts > 0)
        {
            return numberOfContacts;
        }

        var contacts = (await ContactJsonLoader.LoadData(SeedFilePath)).ToList();
        context.Contacts.AddRange(contacts);

        await context.SaveChangesAsync();
        return contacts.Count;
    }
}
