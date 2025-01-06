using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Entities;
using ReviewApp.Services;
using ReviewApp.ViewModels;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    [Authorize]
    public class AccountController : Controller {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index(Guid userId)
        {
            ViewData["UserId"] = userId;

            return View(userId);
        }

        public IActionResult FindUsers()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FindUsers(SearchUsersViewModel viewModel)
        {
            if (ModelState.IsValid) {
                viewModel.SearchHits = await _accountService.SearchUsersAsync(viewModel);
            }
            return View(viewModel);
        }


        public async Task<IActionResult> FollowUser(string followerId, string followeeId)
        {
            try
            {
                await _accountService.FollowUserAsync(followerId, followeeId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return RedirectToAction("Index", "Account",new { UserId = followeeId } );
        }

        public async Task<IActionResult> UnfollowUser(string followerId, string followeeId)
        {
            try
            {
                await _accountService.UnfollowUserAsync(followerId, followeeId);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return RedirectToAction("Index", "Account", new { UserId = followeeId });
        }
    }
}
