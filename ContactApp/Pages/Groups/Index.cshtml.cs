using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ContactGroupServices;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ContactApp.Pages.Groups;

public class Index(IListContactGroupsService service) : PageModel
{
    public List<ContactGroupListDto> ContactGroups { get; set; } = null!;

    public async Task OnGet()
    {
        ContactGroups = await service.ListContactGroups();
    }
}
