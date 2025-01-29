namespace ServiceLayer.ContactServices.Dtos;

/// <summary>
/// Options
/// </summary>
public class ListContactsOptions
{
    /// <summary>
    /// Number of items per page
    /// </summary>
    public const int ItemsPerPage = 10;

    /// <summary>
    /// Search contacts by
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Chosen sorting
    /// </summary>
    public SortContactsBy SortBy { get; set; }
}
