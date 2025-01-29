using System.ComponentModel.DataAnnotations;
using DataLayer.Model;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices;

/// <summary>
/// Service responsible for editing contacts
/// </summary>
public interface IEditContactService : IBusinessService
{
    /// <summary>
    /// Get information about a contact by ID
    /// </summary>
    Task<EditContactDto?> FindById(int id);

    /// <summary>
    /// Validation errors that occurred while updating
    /// </summary>
    IEnumerable<ValidationResult> Errors { get; }

    /// <summary>
    /// Update information about a contact
    /// </summary>
    Task<Contact> UpdateContact(EditContactDto dto);

    /// <summary>
    /// Get list of available contact groups
    /// </summary>
    Task<List<string>> GetAvailableGroups();
}
