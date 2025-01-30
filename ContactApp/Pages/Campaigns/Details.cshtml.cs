using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CampaignServices;

namespace ContactApp.Pages.Campaigns;

public class Details(IViewCampaignDetailsService service) : PageModel
{
    public Campaign Campaign { get; set; } = null!;

    public async Task<IActionResult> OnGet(int campaignId)
    {
        var campaign = await service.GetDetails(campaignId);
        if (campaign is null) return RedirectToPage("Index");
        Campaign = campaign;
        return Page();
    }
}
