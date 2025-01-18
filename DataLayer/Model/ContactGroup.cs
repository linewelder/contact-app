using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model;

/// <summary>
/// Group of contacts, for example to use in marketing a campaign
/// </summary>
public class ContactGroup
{
    /// <summary>
    /// Maximum length of the name property
    /// </summary>
    public const int MaxNameLength = 50;

    /// <summary>
    /// Unique ID
    /// </summary>
    public int ContactGroupId { get; set; }

    /// <summary>
    /// Name of the group
    /// </summary>
    [Required, StringLength(MaxNameLength)]
    public required string Name { get; set; }

    /// <summary>
    /// Navigation collection for the contacts in the group
    /// </summary>
    public ICollection<Contact> Contacts { get; set; } = null!;
}
