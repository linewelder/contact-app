using DataLayer.Data;
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
}
