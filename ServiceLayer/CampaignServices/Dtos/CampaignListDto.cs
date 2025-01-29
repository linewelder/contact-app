using System.ComponentModel.DataAnnotations;
using DataLayer.Model;

namespace ServiceLayer.CampaignServices.Dtos;

/// <summary>
/// DTO containing information displayed about a marketing campaign in a list
/// </summary>
public class CampaignListDto
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public required int CampaignId { get; set; }

    /// <summary>
    /// Subject of the message
    /// </summary>
    [Required, StringLength(Campaign.MaxSubjectLength)]
    public required string Subject { get; set; }

    /// <summary>
    /// When the campaign took place
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Number of contacts targeted in the campaign
    /// </summary>
    public required int NumberContactsTargeted { get; set; }

    /// <summary>
    /// Name of the contact group targeted in the campaign
    /// </summary>
    public required string TargetGroup { get; set; }
}
