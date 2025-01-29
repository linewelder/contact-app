using System.ComponentModel.DataAnnotations;
using DataLayer.Model;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices;

/// <summary>
/// Service responsible for creating contacts
/// </summary>
public interface ICreateContactService : IBusinessService
{
    /// <summary>
    /// Validation errors
    /// </summary>
    IEnumerable<ValidationResult> Errors { get; }

    /// <summary>
    /// Create new contact based on given information
    /// </summary>
    Task<Contact?> CreateContact(EditContactDto dto);

    /// <summary>
    /// Get list of available contact groups
    /// </summary>
    Task<List<string>> GetAvailableGroups();
}
