using DataLayer.Data;
using ServiceLayer.CampaignServices.Dtos;
using ServiceLayer.ContactServices.Dtos;

namespace ServiceLayer.CampaignServices.Concrete;

/// <summary>
/// Service responsible for listing marketing campaigns
/// </summary>
public class ListCampaignsService(AppDbContext context): IListCampaignsService
{
    public async Task<(List<CampaignListDto> Items, int TotalCount)> ListCampaigns(ListCampaignsOptions options)
    {
        return await context.Campaigns
            .ToCampaignListDto()
            .PageAsync(options.PageNumber, ListContactsOptions.ItemsPerPage);
    }
}
