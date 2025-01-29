using System.ComponentModel.DataAnnotations;

namespace DataLayer.Model;

/// <summary>
/// Marketing campaign that happened at some point
/// </summary>
public class Campaign
{
    /// <summary>
    /// Max length of the subject attribute
    /// </summary>
    public const int MaxSubjectLength = 100;

    /// <summary>
    /// Max length of the contents attribute
    /// </summary>
    public const int MaxContentsLength = 1000;

    /// <summary>
    /// Unique ID
    /// </summary>
    public int CampaignId { get; set; }

    /// <summary>
    /// Subject of the message
    /// </summary>
    [Required, StringLength(MaxSubjectLength)]
    public required string Subject { get; set; }

    /// <summary>
    /// Contents of the message
    /// </summary>
    [Required, StringLength(MaxContentsLength)]
    public required string Contents { get; set; }

    /// <summary>
    /// When the campaign took place
    /// </summary>
    public required DateTime Date { get; set; }

    /// <summary>
    /// Number of contacts targeted in the campaign
    /// </summary>
    public required int NumberContactsTargeted { get; set; }

    /// <summary>
    /// Contact group targeted in the campaign
    /// </summary>
    public required ContactGroup TargetGroup { get; set; }
}
