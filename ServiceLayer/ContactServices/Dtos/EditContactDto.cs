using System.ComponentModel.DataAnnotations;
using DataLayer.Model;

namespace ServiceLayer.ContactServices.Dtos;

/// <summary>
/// DTO containing information to update a contact
/// </summary>
public class EditContactDto
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public int ContactId { get; set; }

    /// <summary>
    /// First name
    /// </summary>
    [Display(Name = "First Name")]
    [Required, MaxLength(Contact.MaxNameLength)]
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    [Display(Name = "Last Name")]
    [Required, MaxLength(Contact.MaxNameLength)]
    public required string LastName { get; set; }

    /// <summary>
    /// E-mail address
    /// </summary>
    [Display(Name = "E-mail Address")]
    [Required, MaxLength(Contact.MaxEmailLength), EmailAddress]
    public required string Email { get; set; }

    /// <summary>
    /// Contact groups the contact belongs to
    /// </summary>
    [Display(Name = "Groups")]
    public List<string> ContactGroups { get; set; } = [];
}
