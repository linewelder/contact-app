using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer;
using ServiceLayer.ContactServices;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Contacts;

public class Index(IListContactsService service) : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? Search { get; set; }

    [BindProperty(SupportsGet = true)]
    public SortContactsBy SortBy { get; set; }

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; }

    public int TotalPages { get; set; }

    public List<ContactListDto> ContactList { get; private set; } = [];

    public async Task OnGetAsync()
    {
        if (PageNumber < 1) PageNumber = 1;

        var contacts = await service.ListContacts(new ListContactsOptions
        {
            Search = Search,
            SortBy = SortBy,
            PageNumber = PageNumber,
        }).PageAsync(PageNumber - 1, ListContactsOptions.ItemsPerPage);

        ContactList = contacts.Items;
        TotalPages = UiHelpers.TotalItemsToPages(contacts.TotalCount, ListContactsOptions.ItemsPerPage);
    }
}
