using System.ComponentModel.DataAnnotations;

namespace LongDistanceService.Web.Models.Identity;

public class RegisterUserModel
{
    [Required(ErrorMessage = "Требуется email"), RegularExpression(@"^\S+@\S+\.\S+$", ErrorMessage = "Некорректный email")] 
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Требуется пароль"), RegularExpression(@"\d{1,}", ErrorMessage = "ЛЕГКИЙ РЕЖИМ, на проде фиг введете)))")]
    public string Password { get; set; } = string.Empty;
    [Required(ErrorMessage = "Требуется повтор пароля"), RegularExpression(@"\d{1,}", ErrorMessage = "ЛЕГКИЙ РЕЖИМ, на проде фиг введете)))")]
    public string PasswordRepeat { get; set; } = string.Empty;
    
// Has minimum 8 characters in length. Adjust it by modifying {8,}
// At least one uppercase English letter. You can remove this condition by removing (?=.*?[A-Z])
// At least one lowercase English letter.  You can remove this condition by removing (?=.*?[a-z])
// At least one digit. You can remove this condition by removing (?=.*?[0-9])
// At least one special character,  You can remove this condition by removing (?=.*?[#?!@$%^&*-])
// И ВСЕ ЭТО ВОТ ТУТ -----------> ^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$
}