using DataLayer.Model;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices;

/// <summary>
/// Reusable parts of queries
/// </summary>
public static class QueryObjects
{
    /// <summary>
    /// Convert the Contact objects in the query into ContactListDto
    /// </summary>
    public static IQueryable<ContactListDto> ToContactListDto(this IQueryable<Contact> contacts) =>
        contacts.Select(contact => new ContactListDto
        {
            ContactId = contact.ContactId,
            FirstName = contact.FirstName,
            LastName = contact.LastName,
            Email = contact.Email,
            ContactGroups = contact.ContactGroups.Select(group => group.Name).ToList(),
        });

    public static IOrderedQueryable<Contact> SortContactsBy(this IQueryable<Contact> contacts, SortContactsBy sortBy) =>
        sortBy switch
        {
            Dtos.SortContactsBy.FullName => contacts
                .OrderBy(contact => contact.FirstName)
                .ThenBy(contact => contact.LastName),
            Dtos.SortContactsBy.Email => contacts.OrderBy(contact => contact.Email),
            _ => throw new ArgumentOutOfRangeException(nameof(sortBy)),
        };

    /// <summary>
    /// Search contacts by email and full name
    /// </summary>
    public static IQueryable<Contact> FilterByEmailOrName(this IQueryable<Contact> contacts, string search) =>
        contacts.Where(contact =>
            contact.Email.Contains(search)
            || (contact.FirstName + " " + contact.LastName).Contains(search));
}
