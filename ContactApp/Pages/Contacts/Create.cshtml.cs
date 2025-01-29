using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.ContactServices;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Contacts;

public class Create(ICreateContactService service) : PageModel
{
    [BindProperty]
    public EditContactDto Contact { get; set; } = null!;

    public List<SelectListItem> AvailableGroups { get; set; } = null!;

    public async Task<IActionResult> OnGet()
    {
        await PopulatePage();
        return Page();
    }

    public async Task<IActionResult> OnPost()
    {
        await service.CreateContact(Contact);

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
