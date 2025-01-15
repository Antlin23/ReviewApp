using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.ViewModels;
using ReviewApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ReviewApp.Services;

namespace ReviewApp.Controllers {
    public class AuthenticationController : Controller {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AuthenticationService _authService;

        public AuthenticationController(UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager, AuthenticationService authService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult UserRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (await _userManager.Users.AnyAsync(x => x.UserName == viewModel.UserName))
                    {
                        ModelState.AddModelError("", "Användarnamnet finns redan");
                        return View(viewModel);
                    }
                    if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
                    {
                        var result = await _authService.UserRegisterAsync(viewModel);
                        if (result.Succeeded) {
                            return RedirectToAction("UserLogin", "Authentication");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Något gick fel, välj logga in om du redan har ett konto.");
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return View(viewModel);
        }

        public IActionResult UserLogin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(viewModel.Email);

                if (user == null) {
                    ModelState.AddModelError("", "Något gick snett, registrera konto om du är ny");
                    return View(viewModel);
                }

                var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, true, false);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Account");
                else
                    ModelState.AddModelError("", "Något gick snett");

                return View(viewModel);
            }

            return View(viewModel);
        }

        public async Task<IActionResult> UserLogout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
