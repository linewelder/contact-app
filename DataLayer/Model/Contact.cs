using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model;

/// <summary>
/// Contact in the app
/// </summary>
public class Contact
{
    /// <summary>
    /// Maximum length of the name properties
    /// </summary>
    public const int MaxNameLength = 50;

    /// <summary>
    /// Maximum length of the email properties
    /// </summary>
    public const int MaxEmailLength = 254;

    /// <summary>
    /// Unique ID
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    [Required, StringLength(MaxNameLength)]
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [Required, StringLength(MaxNameLength)]
    public required string LastName { get; set; }

    /// <summary>
    /// E-mail address
    /// </summary>
    [Required, StringLength(MaxEmailLength), EmailAddress]
    public required string Email { get; set; }

    /// <summary>
    /// Contact groups the contact belongs to
    /// </summary>
    public ICollection<ContactGroup> ContactGroups { get; set; } = null!;
}
