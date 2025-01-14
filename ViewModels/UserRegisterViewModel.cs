using ReviewApp.Entities;
using System.ComponentModel.DataAnnotations;

namespace ReviewApp.ViewModels {
    public class UserRegisterViewModel {

        [Required(ErrorMessage = "Du måste ange användarnamn")]
        [StringLength(20, ErrorMessage = "Användarnamnet måste vara minst 3 tecken långt", MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z0-9._]*$", ErrorMessage = "Användarnamnet får endast innehålla bokstäver (inte åäö), siffror, punkter och understreck.")]
        public string UserName { get; set; } = null!;
        [Required(ErrorMessage = "Du måste ange epostadress")]
        public string Email { get; set; } = null!;
        [Required(ErrorMessage = "Du måste ange ett lösenord")]
        [StringLength(40, ErrorMessage = "Lösenordet måste vara minst 5 tecken långt", MinimumLength = 5)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d).*$", ErrorMessage = "Lösenordet måste inehålla minst en bokstav och en siffra")]
        public string Password { get; set; } = null!;

        public static implicit operator UserEntity(UserRegisterViewModel viewModel)
        {
            return new UserEntity
            {
                UserName = viewModel.UserName,
                Email = viewModel.Email,
            };
        }
    }
}
