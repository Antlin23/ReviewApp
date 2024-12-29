﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.ViewModels;
using ReviewApp.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    public class AuthenticationController : Controller {
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AuthenticationController(UserManager<UserEntity> userManager, AppDbContext appDbContext, SignInManager<UserEntity> signInManager)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
            _signInManager = signInManager;
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
                    if (!await _userManager.Users.AnyAsync(x => x.Email == viewModel.Email))
                    {
                        var result = await _userManager.CreateAsync(viewModel, viewModel.Password);

                        //if user is created, add the role user 
                        if (result.Succeeded)
                        {
                            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == viewModel.Email);
                            if (user != null)
                                await _userManager.AddToRoleAsync(user, "user");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return View();
                }
                return RedirectToAction("Index", "Home");
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

                var result = await _signInManager.PasswordSignInAsync(user.UserName, viewModel.Password, true, false);

                if(result.Succeeded)
                    return RedirectToAction("Index", "Account");
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