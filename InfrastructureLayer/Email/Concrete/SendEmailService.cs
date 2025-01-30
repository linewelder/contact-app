using System.Net.Mail;
using InfrastructureLayer.Email.Dtos;
using Microsoft.Extensions.Options;

namespace InfrastructureLayer.Email.Concrete;

/// <summary>
/// Service responsible for sending e-mail
/// </summary>
public class SendEmailService : ISendEmailService
{
    private readonly SmtpClient _client;
    private readonly MailAddress _selfAddress;

    public SendEmailService(IOptions<SmtpClientOptions> options)
    {
        _selfAddress = new MailAddress(options.Value.SelfMailAddress, options.Value.SelfMailDisplayName);
        _client = new SmtpClient(options.Value.Host);
        if (options.Value.Username is not null)
        {
            _client.UseDefaultCredentials = false;
            _client.Credentials = new System.Net.NetworkCredential(options.Value.Username, options.Value.Password);
        }
    }

    public async Task Send(MailAddress to, string subject, string contents)
    {
        var myMail = new MailMessage(_selfAddress, to);

        myMail.Subject = subject;
        myMail.SubjectEncoding = System.Text.Encoding.UTF8;

        myMail.Body = contents;
        myMail.BodyEncoding = System.Text.Encoding.UTF8;
        myMail.IsBodyHtml = false;

        await _client.SendMailAsync(myMail);
    }
}
