namespace ServiceLayer.ContactGroupServices.Dtos;

/// <summary>
/// Information about a contact group to be shown in a list
/// </summary>
public class ContactGroupListDto
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public required int ContactGroupId { get; set; }

    /// <summary>
    /// Name of the contact group
    /// </summary>
    public required string Name { get; set; }

    /// <summary>
    /// Number of contacts in the group
    /// </summary>
    public required int NumberOfContacts { get; set; }

    /// <summary>
    /// Number of campaigns targeting this group
    /// </summary>
    public required int NumberOfCampaigns { get; set; }
}
