using System.ComponentModel.DataAnnotations;

namespace InfrastructureLayer.Email.Dtos;

/// <summary>
/// Options used for SMTP communication
/// </summary>
public class SmtpClientOptions
{
    /// <summary>
    /// Name of the configuration section
    /// </summary>
    public const string ConfigurationSectionName = "Smtp";

    /// <summary>
    /// Host name of the SMTP server
    /// </summary>
    [Required]
    public required string Host { get; set; }

    /// <summary>
    /// Username to authenticate on the SMTP server
    /// </summary>
    public required string? Username { get; set; }

    /// <summary>
    /// Password to authenticate on the SMTP server
    /// </summary>
    public required string? Password { get; set; }

    /// <summary>
    /// E-mail address to use when sending e-mail
    /// </summary>
    [Required, EmailAddress]
    public required string SelfMailAddress { get; set; }

    /// <summary>
    /// Display name to use when sending e-mail
    /// </summary>
    [Required]
    public required string SelfMailDisplayName { get; set; }
}
