using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models;
// todo: user checks
public class User : IUser
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string Surname { get; set; } = String.Empty;
    public IRole Role { get; set; }
}