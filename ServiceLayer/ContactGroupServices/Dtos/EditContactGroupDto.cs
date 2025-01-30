using System.ComponentModel.DataAnnotations;
using DataLayer.Model;

namespace ServiceLayer.ContactGroupServices.Dtos;

public class EditContactGroupDto
{
    /// <summary>
    /// Unique ID
    /// </summary>
    public required int ContactGroupId { get; set; }

    /// <summary>
    /// Name of the contact group
    /// </summary>
    [Required, MaxLength(ContactGroup.MaxNameLength)]
    public required string Name { get; set; }
}
