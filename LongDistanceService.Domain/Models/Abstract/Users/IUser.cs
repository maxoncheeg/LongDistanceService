namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
    public IRole Role { get; set; }
}