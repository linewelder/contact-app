namespace ServiceLayer.CampaignServices.Dtos;

/// <summary>
/// DTO containing information about a new marketing campaign
/// </summary>
public class NewCampaignDto
{
    /// <summary>
    /// Name of the target group
    /// </summary>
    public required string TargetGroup { get; set; }

    /// <summary>
    /// Subject of the message
    /// </summary>
    public required string Subject { get; set; }

    /// <summary>
    /// Contents of the message
    /// </summary>
    public required string Contents { get; set; }
}
