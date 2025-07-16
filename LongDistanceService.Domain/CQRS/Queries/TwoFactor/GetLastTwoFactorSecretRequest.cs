using LongDistanceService.Domain.CQRS.Responses.TwoFactors;
using LongDistanceService.Domain.Enums;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Queries.TwoFactor;

public record GetLastTwoFactorSecretRequest(int UserId, CodeReason CodeReason) : IRequest<TwoFactorSecretResponse?>;