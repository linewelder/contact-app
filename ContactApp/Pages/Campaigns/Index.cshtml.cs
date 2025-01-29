using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CampaignServices;
using ServiceLayer.CampaignServices.Dtos;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Campaigns;

public class Index(IListCampaignsService service) : PageModel
{
    public List<CampaignListDto> Campaigns { get; set; } = null!;

    public int TotalPages { get; set; }

    [BindProperty(SupportsGet = true)]
    public int PageNumber { get; set; } = 1;

    public async Task OnGet()
    {
        if (PageNumber < 1) PageNumber = 1;

        var campaigns = await service.ListCampaigns(new ListCampaignsOptions
        {
            PageNumber = PageNumber - 1,
        });

        Campaigns = campaigns.Items;
        TotalPages = UiHelpers.TotalItemsToPages(campaigns.TotalCount, ListContactsOptions.ItemsPerPage);
    }
}
