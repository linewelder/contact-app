using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.ContactServices;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Contacts;

public class Edit(IEditContactService service) : PageModel
{
    [BindProperty]
    public EditContactDto Contact { get; set; } = null!;

    public List<SelectListItem> AvailableGroups { get; set; } = null!;

    public async Task<IActionResult> OnGet(int contactId)
    {
        var contact = await service.FindById(contactId);
        if (contact is null)
        {
            return RedirectToPage("Index");
        }

        Contact = contact;
        await PopulatePage();
        return Page();
    }

    public async Task<IActionResult> OnPost(int contactId)
    {
        Contact.ContactId = contactId;
        await service.UpdateContact(Contact);

        if (!service.Errors.Any())
        {
            return RedirectToPage("Index");
        }

        ModelState.AddValidationErrors(service.Errors);
        await PopulatePage();
        return Page();

    }

    private async Task PopulatePage()
    {
        AvailableGroups = (await service.GetAvailableGroups())
            .Select(group => new SelectListItem(group, group))
            .ToList();
    }
}
