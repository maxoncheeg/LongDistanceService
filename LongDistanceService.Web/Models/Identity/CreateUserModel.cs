using System.ComponentModel.DataAnnotations;

namespace LongDistanceService.Web.Models.Identity;

public class CreateUserModel
{
    [Required, MinLength(2)]  public string Login { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Password { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Name { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Surname { get; set; } = string.Empty;
    public int RoleId { get; set; }
}