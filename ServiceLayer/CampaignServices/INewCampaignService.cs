using System.ComponentModel.DataAnnotations;
using DataLayer.Model;
using ServiceLayer.CampaignServices.Dtos;
using ServiceLayer.ContactServices;

namespace ServiceLayer.CampaignServices;

/// <summary>
/// Service responsible for creating a new marketing campaign
/// </summary>
public interface INewCampaignService : IBusinessService
{
    /// <summary>
    /// List available contact groups
    /// </summary>
    Task<List<string>> GetAvailableGroups();

    /// <summary>
    /// Get number of contacts in the group with a name
    /// </summary>
    Task<int> GetContactCountInGroup(string groupName);

    /// <summary>
    /// Validation errors that occurred while updating
    /// </summary>
    IEnumerable<ValidationResult> Errors { get; }

    /// <summary>
    /// Broadcast a marketing campaign
    /// </summary>
    Task<Campaign?> BroadcastCampaign(NewCampaignDto dto);
}
