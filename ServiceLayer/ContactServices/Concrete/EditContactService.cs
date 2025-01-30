using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices.Concrete;

/// <summary>
/// Service responsible for editing contacts
/// </summary>
public class EditContactService(AppDbContext context) : IEditContactService
{
    public async Task<EditContactDto?> FindById(int id)
    {
        var contact = await FindContactWithGroups(id);
        if (contact is null) return null;

        return EditContactDto.FromContact(contact);
    }

    public IEnumerable<ValidationResult> Errors { get; private set; } = [];

    public async Task<Contact> UpdateContact(EditContactDto dto)
    {
        var contact = await FindContactWithGroups(dto.ContactId)
                      ?? throw new InvalidOperationException("Contact with ID not found");

        contact.FirstName = dto.FirstName;
        contact.LastName = dto.LastName;
        contact.Email = dto.Email;
        contact.ContactGroups = await FindGroupsByNames(dto.ContactGroups);

        Errors = await context.SaveChangesWithValidationAsync();
        return contact;
    }

    public async Task<List<string>> GetAvailableGroups() =>
        await context.ContactGroups.Select(group => group.Name).ToListAsync();

    private async Task<Contact?> FindContactWithGroups(int id) =>
        await context.Contacts
            .Include(contact => contact.ContactGroups)
            .SingleOrDefaultAsync(contact => contact.ContactId == id);

    private async Task<List<ContactGroup>> FindGroupsByNames(List<string> names) =>
        await context.ContactGroups
            .Join(
                names,
                group => group.Name,
                name => name,
                (group, name) => group)
            .ToListAsync();
}
