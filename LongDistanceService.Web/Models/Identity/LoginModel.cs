using System.ComponentModel.DataAnnotations;

namespace LongDistanceService.Web.Models.Identity;

public class LoginModel
{
    [Required, MinLength(2)]  public string Email { get; set; } = string.Empty;
    [Required, MinLength(2)] public string Password { get; set; } = string.Empty;
}