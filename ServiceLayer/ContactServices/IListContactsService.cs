using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.ContactServices;

public interface IListContactsService : IBusinessService
{
    IQueryable<ContactListDto> ListContacts(ListContactsOptions options);
}
