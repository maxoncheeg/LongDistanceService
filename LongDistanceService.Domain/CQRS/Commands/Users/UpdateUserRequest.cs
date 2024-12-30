using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class UpdateUserRequest : IRequest<bool>, IUser
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public IRole Role { get; set; } = null!;
}