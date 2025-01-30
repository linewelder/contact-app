using ServiceLayer.ContactGroupServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.ContactGroupServices;

public interface IListContactGroupsService : IBusinessService
{
    Task<List<ContactGroupListDto>> ListContactGroups();
}
