using System.ComponentModel.DataAnnotations;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ServiceLayer.ContactGroupServices.Concrete;

public class ListContactGroupsService(AppDbContext context) : IListContactGroupsService
{
    public async Task<List<ContactGroupListDto>> ListContactGroups() =>
        await context.ContactGroups
            .OrderBy(group => group.Name)
            .ToContactGroupListDto()
            .ToListAsync();

    public IEnumerable<ValidationResult> Errors { get; private set; } = [];

    public async Task<ContactGroup?> CreateContactGroup(string name)
    {
        if (await GroupWithNameExists(name))
        {
            Errors = [new ValidationResult($"Group with name {name} already exists", [nameof(name)])];
            return null;
        }

        var group = new ContactGroup
        {
            Name = name,
        };

        context.Add(group);
        Errors = await context.SaveChangesWithValidationAsync();
        return Errors.Any() ? null : group;
    }

    private async Task<bool> GroupWithNameExists(string name) =>
        await context.ContactGroups.AnyAsync(group => group.Name == name);
}
