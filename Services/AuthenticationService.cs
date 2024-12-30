using Microsoft.AspNetCore.Identity;
using ReviewApp.Entities;
using ReviewApp.ViewModels;
using System.Diagnostics;

namespace ReviewApp.Services {
    public class AuthenticationService {
        private readonly UserManager<UserEntity> _userManager;

        public AuthenticationService(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task UserRegisterAsync(UserRegisterViewModel viewModel)
        {
            var result = await _userManager.CreateAsync(viewModel, viewModel.Password);

            //if user is created, add the role user 
            //Roles is not created right now
            /*
            if (result.Succeeded)
            {
                var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
                 if (user != null)
                     await _userManager.AddToRoleAsync(user, "user");
            }
            */
        }

    }
}
