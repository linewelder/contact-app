using DataLayer.Model;

namespace ServiceLayer.ContactServices;

/// <summary>
/// Service responsible for deleting contacts
/// </summary>
public interface IDeleteContactService : IBusinessService
{
    /// <summary>
    /// Get details of a contact
    /// </summary>
    Task<Contact?> GetDetails(int contactId);

    /// <summary>
    /// Delete contact by ID
    /// </summary>
    Task<bool> DeleteById(int contactId);
}
