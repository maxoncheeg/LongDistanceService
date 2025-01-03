using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class CreateUserRequest : IRequest<bool>
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public int RoleId { get; set; } = 2;
}