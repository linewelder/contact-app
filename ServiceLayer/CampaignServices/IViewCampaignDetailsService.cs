using DataLayer.Model;
using ServiceLayer.ContactServices;

namespace ServiceLayer.CampaignServices;

public interface IViewCampaignDetailsService : IBusinessService
{
    Task<Campaign?> GetDetails(int campaignId);
}
