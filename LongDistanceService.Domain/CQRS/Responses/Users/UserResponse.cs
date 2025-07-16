using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public class UserResponse : IUser
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public bool IsEmailVerified { get; set; }
    public bool IsExternalUser { get; set; }
    public IList<IRole> Roles { get; set; } = null!;
}