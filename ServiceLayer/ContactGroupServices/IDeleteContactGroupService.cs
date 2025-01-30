using ServiceLayer.ContactGroupServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.ContactGroupServices;

/// <summary>
/// Service responsible for deleting contact groups
/// </summary>
public interface IDeleteContactGroupService : IBusinessService
{
    Task<DeleteContactGroupDto?> GetDetails(int groupId);
    Task<bool> DeleteById(int groupId);
}
