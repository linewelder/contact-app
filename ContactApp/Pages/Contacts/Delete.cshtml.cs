using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ContactServices;

namespace ContactApp.Pages.Contacts;

public class Delete(IDeleteContactService service) : PageModel
{
    public Contact Contact { get; set; } = null!;

    public async Task<IActionResult> OnGet(int contactId)
    {
        var contact = await service.GetDetails(contactId);
        if (contact is null)
        {
            return RedirectToPage("Index");
        }

        Contact = contact;
        return Page();
    }

    public async Task<IActionResult> OnPost(int contactId)
    {
        await service.DeleteById(contactId);
        return RedirectToPage("Index");
    }
}
