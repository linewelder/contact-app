using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.ContactServices.Concrete;

public class DeleteContactService(AppDbContext context) : IDeleteContactService
{
    public async Task<Contact?> GetDetails(int contactId)
    {
        return await context.Contacts
            .Include(contact => contact.ContactGroups)
            .SingleOrDefaultAsync(contact => contact.ContactId == contactId);
    }

    public async Task<bool> DeleteById(int contactId)
    {
        var contact = await GetDetails(contactId);
        if (contact is null) return false;

        context.Remove(contact);
        await context.SaveChangesAsync();
        return true;
    }
}
