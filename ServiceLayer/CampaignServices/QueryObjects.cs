using DataLayer.Model;
using ServiceLayer.CampaignServices.Dtos;

namespace ServiceLayer.CampaignServices;

/// <summary>
/// Reusable parts of queries
/// </summary>
public static class QueryObjects
{
    /// <summary>
    /// Convert query of campaigns to CampaignListDto
    /// </summary>
    public static IQueryable<CampaignListDto> ToCampaignListDto(this IQueryable<Campaign> campaigns) =>
        campaigns.Select(campaign => new CampaignListDto
        {
            CampaignId = campaign.CampaignId,
            Subject = campaign.Subject,
            Date = campaign.Date,
            NumberContactsTargeted = campaign.NumberContactsTargeted,
            TargetGroup = campaign.TargetGroup.Name,
        });
}
