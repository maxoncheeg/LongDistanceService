using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Tests.Mocks;

public class MockUser : IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
    public bool IsEmailVerified { get; set; }
    public bool IsExternalUser { get; set; }
    public IList<IRole> Roles { get; set; }
}