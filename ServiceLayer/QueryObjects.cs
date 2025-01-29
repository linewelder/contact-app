using Microsoft.EntityFrameworkCore;

namespace ServiceLayer;

/// <summary>
/// Reusable parts of queries
/// </summary>
public static class QueryObjects
{
    /// <summary>
    /// Page query
    /// </summary>
    /// <param name="query">The query</param>
    /// <param name="page">Current page number</param>
    /// <param name="perPage"></param>
    /// <typeparam name="T">Type of a single element in the query</typeparam>
    /// <returns>The items on the current page and the total count of items</returns>
    public static async Task<(List<T> Items, int TotalCount)> PageAsync<T>(
        this IQueryable<T> query, int page, int perPage)
    {
        return (
            Items: await query
                .Skip(page * perPage)
                .Take(perPage)
                .ToListAsync(),
            TotalCount: await query.CountAsync()
        );
    }
}
