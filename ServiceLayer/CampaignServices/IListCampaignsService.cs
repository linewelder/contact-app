using ServiceLayer.CampaignServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.CampaignServices;

/// <summary>
/// Service responsible for listing marketing campaigns
/// </summary>
public interface IListCampaignsService : IBusinessService
{
    /// <summary>
    /// Get list of campaigns with the total count
    /// </summary>
    Task<(List<CampaignListDto> Items, int TotalCount)> ListCampaigns(ListCampaignsOptions options);
}
