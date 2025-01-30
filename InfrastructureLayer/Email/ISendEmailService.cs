using System.Net.Mail;

namespace InfrastructureLayer.Email;

/// <summary>
/// Service responsible for sending e-mail
/// </summary>
public interface ISendEmailService : IInfrastructureService
{
    /// <summary>
    /// Send e-mail
    /// </summary>
    /// <param name="to">The recipient address</param>
    /// <param name="subject">Subject of the e-mail</param>
    /// <param name="contents">Contents of the e-mail</param>
    Task Send(MailAddress to, string subject, string contents);
}
