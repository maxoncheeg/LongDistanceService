using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models;

public class LoginUser(int id) : ILoginUser
{
    public int Id { get; } = id;
    public string Login { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}