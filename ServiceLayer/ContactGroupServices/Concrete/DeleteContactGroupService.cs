using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ServiceLayer.ContactGroupServices.Concrete;

/// <summary>
/// Service responsible for deleting contact groups
/// </summary>
public class DeleteContactGroupService(AppDbContext context) : IDeleteContactGroupService
{
    public async Task<DeleteContactGroupDto?> GetDetails(int groupId)
    {
        var group = await FindWithContactsById(groupId);
        if (group is null) return null;

        return new DeleteContactGroupDto
        {
            ContactGroupId = groupId,
            Name = group.Name,
            NumberOfContacts = group.Contacts.Count,
            NumberOfCampaigns = await CountCampaignsForGroup(group),
            CanBeDeleted = await CanBeDeleted(group),
        };
    }

    public async Task<bool> DeleteById(int groupId)
    {
        var group = await FindWithContactsById(groupId);
        if (group is null || !await CanBeDeleted(group)) return false;

        context.Remove(group);
        await context.SaveChangesAsync();
        return true;
    }

    private async Task<ContactGroup?> FindWithContactsById(int groupId) =>
        await context.ContactGroups
            .Include(group => group.Contacts)
            .SingleOrDefaultAsync(group => group.ContactGroupId == groupId);

    private async Task<bool> CanBeDeleted(ContactGroup group) =>
        await CountCampaignsForGroup(group) == 0;

    private async Task<int> CountCampaignsForGroup(ContactGroup group) =>
        await context.Entry(group).Collection(g => g.Campaigns).Query().CountAsync();
}
