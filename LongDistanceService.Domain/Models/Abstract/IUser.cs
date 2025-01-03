using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Models.Abstract;

public interface IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public IRole Role { get; set; }
}