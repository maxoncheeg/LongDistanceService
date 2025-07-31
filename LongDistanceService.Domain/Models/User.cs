using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models;
// todo: user checks
public class User : IUser
{
    public int Id { get; set; }
    public string Email { get; set; } = String.Empty;
    public bool IsEmailVerified { get; set; }
    public bool IsExternalUser { get; set; }
    public IList<IRole> Roles { get; set; } = [];
}