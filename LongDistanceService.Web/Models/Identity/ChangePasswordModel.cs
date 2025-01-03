using System.ComponentModel.DataAnnotations;

namespace LongDistanceService.Web.Models.Identity;

public class ChangePasswordModel
{
    [Required] public string OldPassword { get; set; } = string.Empty;
    [Required] public string NewPassword { get; set; } = string.Empty;
    [Required] public string ConfirmPassword { get; set; } = string.Empty;
}