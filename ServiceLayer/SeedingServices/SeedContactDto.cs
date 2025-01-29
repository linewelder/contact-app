namespace ServiceLayer.SeedingServices;

public class SeedContactDto
{
    /// <summary>
    /// First name
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// Last name
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// E-mail address
    /// </summary>
    public required string Email { get; set; }

    /// <summary>
    /// Contact groups the contact belongs to
    /// </summary>
    public required IReadOnlyList<string> Groups { get; set; }
}
