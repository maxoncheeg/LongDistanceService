using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.CQRS.Responses.Users;

public class RoleResponse : IRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}