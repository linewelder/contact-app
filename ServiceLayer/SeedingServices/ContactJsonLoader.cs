using System.Text.Json;
using DataLayer.Model;

namespace ServiceLayer.SeedingServices;

/// <summary>
/// Loads contact data from a JSON file for database seeding
/// </summary>
public class ContactJsonLoader
{
    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    /// <summary>
    /// Load contact data from a JSON file
    /// </summary>
    public static async Task<IEnumerable<Contact>> LoadData(string dataFilePath)
    {
        await using var stream = File.OpenRead(dataFilePath);
        var data = await JsonSerializer.DeserializeAsync<SeedContactDto[]>(stream, JsonSerializerOptions);

        var groups = data!
            .SelectMany(contact => contact.Groups)
            .Distinct()
            .Select(groupName => new ContactGroup { Name = groupName })
            .ToDictionary(group => group.Name, group => group);

        return data!
            .Select(contact => new Contact
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                ContactGroups = contact.Groups.Select(name => groups[name]).ToList(),
            });
    }
}
