using System.ComponentModel.DataAnnotations;

namespace ReviewApp.ViewModels {
    public class UserLoginViewModel {
        [Required(ErrorMessage = "Du måste ange epostadress")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Vänligen ange en korrekt epostadress")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        public string Password { get; set; } = null!;
    }
}
