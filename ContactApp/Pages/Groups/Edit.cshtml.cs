using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.ContactGroupServices;
using ServiceLayer.ContactGroupServices.Dtos;

namespace ContactApp.Pages.Groups;

public class Edit(IEditContactGroupService service) : PageModel
{
    [BindProperty]
    public EditContactGroupDto ContactGroup { get; set; } = null!;

    public async Task<IActionResult> OnGet(int groupId)
    {
        var group = await service.GetDetails(groupId);
        if (group is null) return RedirectToPage("Index");

        ContactGroup = group;
        return Page();
    }

    public async Task<IActionResult> OnPost(int groupId)
    {
        ContactGroup.ContactGroupId = groupId;
        await service.UpdateGroup(ContactGroup);
        if (!service.Errors.Any())
        {
            return RedirectToPage("Index");
        }

        ModelState.AddValidationErrors(service.Errors);
        return Page();
    }
}
