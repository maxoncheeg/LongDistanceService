using System.Net;
using System.Net.Mail;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Services.Factories.Abstract;
using LongDistanceService.Domain.Services.Options;
using LongDistanceService.Domain.Services.Utils.Abstract;

namespace LongDistanceService.Domain.Services.Utils;

public class EmailSender(EmailOptions options, IHtmlCodeTemplateFactory codeTemplateFactory) : IEmailSender
{
    public async Task SendMailAsync(string to, string subject, string body, CancellationToken cancellationToken = default)
    {
        var addressTo = new MailAddress(to);
        var addressFrom = new MailAddress(options.Email);
        var message = new MailMessage(addressFrom, addressTo);

        message.Subject = subject;
        message.Body = body;
        message.IsBodyHtml = true;

        using var client = new SmtpClient(options.Server, options.Port);
        client.Credentials = new NetworkCredential(options.Email, options.Secret);
        client.EnableSsl = true;

        var cts = new CancellationTokenSource(delay: TimeSpan.FromSeconds(options.TimeoutInSeconds));
        var linkedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cts.Token, cancellationToken);
        
        await client.SendMailAsync(message, linkedTokenSource.Token);
    }

    public async Task SendCodeAsync(string to, string code, CodeReason codeReason, CancellationToken cancellationToken = default)
    {
        await SendMailAsync(
            to, 
            "Long Distance Service. Ваш код.",
            codeTemplateFactory.GetHtmlByReason(codeReason, code),
            cancellationToken);
    }
}