using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Models;
// todo: user checks
public class User : IUser
{
    public int Id { get; set; }
    public string Login { get; set; } = String.Empty;
}