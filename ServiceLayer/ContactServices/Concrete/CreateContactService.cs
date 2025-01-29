using System.ComponentModel.DataAnnotations;
using System.Globalization;
using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices.Concrete;

/// <summary>
/// Service responsible for creating contacts
/// </summary>
public class CreateContactService(AppDbContext context) : ICreateContactService
{
    public IEnumerable<ValidationResult> Errors { get; private set; } = [];

    public async Task<Contact?> CreateContact(EditContactDto dto)
    {
        var contact = new Contact
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            ContactGroups = await FindGroupsByNames(dto.ContactGroups),
        };

        context.Add(contact);
        Errors = await context.SaveChangesWithValidationAsync();
        return Errors.Any() ? null : contact;
    }

    public async Task<List<string>> GetAvailableGroups() =>
        await context.ContactGroups.Select(group => group.Name).ToListAsync();

    private async Task<List<ContactGroup>> FindGroupsByNames(List<string> names) =>
        await context.ContactGroups
            .Join(
                names,
                group => group.Name,
                name => name,
                (group, name) => group)
            .ToListAsync();
}
