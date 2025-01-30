using System.ComponentModel.DataAnnotations;
using DataLayer.Model;
using ServiceLayer.ContactGroupServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.ContactGroupServices;

public interface IListContactGroupsService : IBusinessService
{
    /// <summary>
    /// Get list of contact groups
    /// </summary>
    Task<List<ContactGroupListDto>> ListContactGroups();

    /// <summary>
    /// Validation errors
    /// </summary>
    IEnumerable<ValidationResult> Errors { get; }

    /// <summary>
    /// Create a new contact group with the given name
    /// </summary>
    Task<ContactGroup?> CreateContactGroup(string name);
}
