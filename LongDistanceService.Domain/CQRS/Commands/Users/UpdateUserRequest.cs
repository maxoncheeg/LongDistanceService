using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;
using MediatR;

namespace LongDistanceService.Domain.CQRS.Commands.Users;

public class UpdateUserRequest : IRequest<bool>
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public IList<IRole> Roles { get; set; } = null!;
}