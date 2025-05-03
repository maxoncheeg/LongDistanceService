using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public class UserResponse : IUser
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public IRole Role { get; set; } = null!;
}