using System.ComponentModel.DataAnnotations;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Web.Models.Identity;

public class CreateUserModel : IUser
{
    public int Id { get; set; }
    [Required, MinLength(2)]  public string Login { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Password { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Name { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Surname { get; set; } = string.Empty;
    public IRole Role { get; set; } = new RoleModel();
}