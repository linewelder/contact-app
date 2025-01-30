using DataLayer.Model;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ServiceLayer.ContactGroupServices;

/// <summary>
/// Reusable parts of queries
/// </summary>
public static class QueryObjects
{
    public static IQueryable<ContactGroupListDto> ToContactGroupListDto(this IQueryable<ContactGroup> groups) =>
        groups.Select(group => new ContactGroupListDto
        {
            ContactGroupId = group.ContactGroupId,
            Name = group.Name,
            NumberOfContacts = group.Contacts.Count,
            NumberOfCampaigns = group.Campaigns.Count,
        });
}
