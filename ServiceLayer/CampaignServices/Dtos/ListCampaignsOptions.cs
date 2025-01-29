namespace ServiceLayer.CampaignServices.Dtos;

/// <summary>
/// Options
/// </summary>
public class ListCampaignsOptions
{
    /// <summary>
    /// Number of items per page
    /// </summary>
    public const int ItemsPerPage = 10;

    /// <summary>
    /// Current chosen page
    /// </summary>
    public int PageNumber { get; set; }
}
