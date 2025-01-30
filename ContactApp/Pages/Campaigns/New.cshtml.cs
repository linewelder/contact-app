using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ServiceLayer.CampaignServices;
using ServiceLayer.CampaignServices.Dtos;

namespace ContactApp.Pages.Campaigns;

public class New(INewCampaignService service) : PageModel
{
    /// <summary>
    /// Selected contact group
    /// </summary>
    [BindProperty(SupportsGet = true)]
    public string? SelectedGroup { get; set; }

    /// <summary>
    /// DTO of the new campaign
    /// </summary>
    [BindProperty]
    public NewCampaignDto NewCampaignDto { get; set; } = null!;

    /// <summary>
    /// Number of contacts in selected group
    /// </summary>
    public int NumberOfContactsInSelectedGroup { get; set; }

    /// <summary>
    /// Available contact groups
    /// </summary>
    public List<SelectListItem> AvailableGroups { get; set; } = null!;

    public async Task OnGet()
    {
        await PopulatePage();
    }

    public async Task<IActionResult> OnPost()
    {
        if (SelectedGroup is null)
        {
            await PopulatePage();
            return Page();
        }

        NewCampaignDto.TargetGroup = SelectedGroup;
        await service.BroadcastCampaign(NewCampaignDto);
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
        AvailableGroups.Insert(0, new SelectListItem("<select target group>", ""));

        if (SelectedGroup is not null)
        {
            NumberOfContactsInSelectedGroup = await service.GetContactCountInGroup(SelectedGroup);
        }
    }
}
