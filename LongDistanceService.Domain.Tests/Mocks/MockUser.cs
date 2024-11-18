using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Tests.Mocks;

public class MockUser : IUser
{
    public int Id { get; set; }
    public string Login { get; set; }
}