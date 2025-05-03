using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models.Abstract.Auth;

public interface IAuthResult
{
    public bool UserExists { get; }
    public bool IsAuthenticated { get; }
    public IUser? User { get; }
}