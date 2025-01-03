using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Web.Models.Identity;

public class RoleModel : IRole
{
    public int Id { get; set; }
    public string Name { get; set; }
}