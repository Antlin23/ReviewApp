using ReviewApp.Entities;

namespace ReviewApp.ViewModels {
    public class UserRegisterViewModel {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
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
