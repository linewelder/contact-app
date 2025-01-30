using System.ComponentModel.DataAnnotations;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ServiceLayer.ContactGroupServices.Concrete;

/// <summary>
/// Service responsible for editing contact groups
/// </summary>
public class EditContactGroupService(AppDbContext context) : IEditContactGroupService
{
    public async Task<EditContactGroupDto?> GetDetails(int groupId)
    {
        var group = await FindById(groupId);
        if (group is null) return null;

        return new EditContactGroupDto
        {
            ContactGroupId = groupId,
            Name = group.Name,
        };
    }

    public IEnumerable<ValidationResult> Errors { get; private set; } = [];

    public async Task<ContactGroup?> UpdateGroup(EditContactGroupDto dto)
    {
        var group = await FindById(dto.ContactGroupId);
        if (group is null) return null;

        group.Name = dto.Name;

        Errors = await context.SaveChangesWithValidationAsync();
        return Errors.Any() ? null : group;
    }

    private async Task<ContactGroup?> FindById(int groupId) =>
        await context.ContactGroups
            .SingleOrDefaultAsync(group => group.ContactGroupId == groupId);
}
