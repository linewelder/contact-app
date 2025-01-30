namespace ServiceLayer.ContactGroupServices.Dtos;

public class DeleteContactGroupDto
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

    /// <summary>
    /// Can the group be deleted?
    /// </summary>
    public required bool CanBeDeleted { get; set; }
}
