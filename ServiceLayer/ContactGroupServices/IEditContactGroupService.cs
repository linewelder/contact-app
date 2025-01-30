using System.ComponentModel.DataAnnotations;
using DataLayer.Model;
using ServiceLayer.ContactGroupServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.ContactGroupServices;

/// <summary>
/// Service responsible for editing contact groups
/// </summary>
public interface IEditContactGroupService : IBusinessService
{
    Task<EditContactGroupDto?> GetDetails(int groupId);
    IEnumerable<ValidationResult> Errors { get; }
    Task<ContactGroup?> UpdateGroup(EditContactGroupDto dto);
}
