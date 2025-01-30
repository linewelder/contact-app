using DataLayer.Data;
using DataLayer.Model;
using Microsoft.EntityFrameworkCore;

namespace ServiceLayer.CampaignServices.Concrete;

public class ViewCampaignDetailsService(AppDbContext context) : IViewCampaignDetailsService
{
    public async Task<Campaign?> GetDetails(int campaignId) =>
        await context.Campaigns
            .Include(campaign => campaign.TargetGroup)
            .SingleOrDefaultAsync(campaign => campaign.CampaignId == campaignId);
}
