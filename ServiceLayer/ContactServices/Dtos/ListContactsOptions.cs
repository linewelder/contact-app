namespace ServiceLayer.ContactServices.Dtos;

/// <summary>
/// Options
/// </summary>
public class ListContactsOptions
{
    /// <summary>
    /// Search contacts by
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Chosen sorting
    /// </summary>
    public SortContactsBy SortBy { get; set; }
}
