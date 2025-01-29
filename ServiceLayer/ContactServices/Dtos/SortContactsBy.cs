using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.ContactServices.Dtos;

/// <summary>
/// Contact sorting options
/// </summary>
public enum SortContactsBy
{
    /// <summary>
    /// Sort contacts by full name
    /// </summary>
    [Display(Name = "Name")]
    FullName,

    /// <summary>
    /// Sort contacts by email
    /// </summary>
    [Display(Name = "E-mail Address")]
    Email,
}
