namespace ServiceLayer.ContactServices.Dtos;

/// <summary>
/// Information about a contact to be shown in a list
/// </summary>
public class ContactListDto
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// E-mail address
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Contact groups the contact belongs to
    /// </summary>
    public required List<string> ContactGroups { get; set; }
}

