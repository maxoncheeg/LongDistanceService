namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface ILoginUser
{
    public int Id { get; }
    public string Login { get; }
    public string Password { get; }
}