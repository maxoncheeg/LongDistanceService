using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Services.Utils.Abstract;

public interface IEmailSender
{
    public Task SendMailAsync(string to, string subject, string body, CancellationToken cancellationToken = default);
    public Task SendCodeAsync(string to, string code, CodeReason codeReason, CancellationToken cancellationToken = default);
}