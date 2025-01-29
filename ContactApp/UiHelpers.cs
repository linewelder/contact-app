namespace ContactApp;

/// <summary>
/// Static UI helper functions
/// </summary>
public static class UiHelpers
{
    /// <summary>
    /// Get the correct form of a noun depending on the number and concatenate it with it
    /// </summary>
    /// <param name="number">Number of items</param>
    /// <param name="singular">Singular form of the noun</param>
    /// <param name="plural">Plural form of the noun</param>
    public static string Pluralize(int number, string singular, string plural)
    {
        var form = number % 10 == 1 ? singular : plural;
        return $"{number} {form}";
    }

    /// <summary>
    /// Get number of pages out of the total number of items
    /// </summary>
    /// <param name="totalCount">Number of items</param>
    /// <param name="perPage">Number of items per page</param>
    /// <returns></returns>
    public static int TotalItemsToPages(int totalCount, int perPage) =>
        (totalCount + perPage - 1) / perPage;
}
