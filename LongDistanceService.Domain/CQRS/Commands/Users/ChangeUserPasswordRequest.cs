using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class ChangeUserPasswordRequest : IRequest<bool>
{
    public int UserId { get; set; }
    public string NewPassword { get; set; } = string.Empty;
}