using LongDistanceService.Domain.Enums;

namespace LongDistanceService.Domain.Models.Abstract.Users;

public interface IRole
{
    public int Id { get; set; }
    public UserRole Type { get; set; }
}