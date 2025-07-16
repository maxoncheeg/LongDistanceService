using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.TwoFactors;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.TwoFactor;

public record CreateTwoFactorSecretRequest : IRequest<bool>, ITwoFactorSecret
{
    public int Id { get; set; }
    public string Secret { get; set; } = string.Empty;
    public int UserId { get; set; }
    public CodeReason CodeReason { get; set; }
    public DateTime Expires { get; set; }
}