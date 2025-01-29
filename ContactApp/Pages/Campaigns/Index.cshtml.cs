using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.CampaignServices;
using ServiceLayer.CampaignServices.Dtos;
using ServiceLayer.ContactServices.Dtos;

namespace ContactApp.Pages.Campaigns;

public class Index(IListCampaignsService service) : PageModel
{
    public List<CampaignListDto> Campaigns { get; set; } = null!;

    public int TotalPages { get; set; }
    public int PageNumber { get; set; }

    public async Task OnGet()
    {
        var campaigns = await service.ListCampaigns(new ListCampaignsOptions
        {
            PageNumber = PageNumber,
        });

        Campaigns = campaigns.Items;
        TotalPages = UiHelpers.TotalItemsToPages(campaigns.TotalCount, ListContactsOptions.ItemsPerPage);
    }
}
