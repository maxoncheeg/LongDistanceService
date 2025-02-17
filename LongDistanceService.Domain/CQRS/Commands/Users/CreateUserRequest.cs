using LongDistanceService.Domain.Enums;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class CreateUserRequest : IRequest<bool>
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public UserRole Role { get; set; } = UserRole.Client;
}