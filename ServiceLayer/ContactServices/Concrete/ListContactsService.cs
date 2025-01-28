using DataLayer.Data;
using DataLayer.Model;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices.Concrete;

/// <summary>
/// Service responsible for listing contacts
/// </summary>
public class ListContactsService(AppDbContext context) : IListContactsService
{
    /// <inheritdoc/>
    public IQueryable<ContactListDto> ListContacts(ListContactsOptions options)
    {
        IQueryable<Contact> query = context.Contacts;

        if (options.Search is not null)
        {
            query = query.FilterByEmailOrName(options.Search);
        }

        return query
            .SortContactsBy(options.SortBy)
            .ToContactListDto();
    }
}
