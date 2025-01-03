using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Tests.Mocks;

public class MockUser : IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public IRole Role { get; set; }
}