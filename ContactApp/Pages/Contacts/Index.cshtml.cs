using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.ContactServices;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Contacts;

public class Index(IListContactsService service) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public SortContactsBy SortBy { get; set; }

    public List<ContactListDto> ContactList { get; private set; } = [];

    public async Task OnGetAsync()
    {
        ContactList = await service.ListContacts(new ListContactsOptions
        {
            Search = Search,
            SortBy = SortBy,
        }).ToListAsync();
    }
}
