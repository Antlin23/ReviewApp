using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Services;
using ReviewApp.ViewModels;

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


        public IActionResult FollowUser(string followerId, string followeeId)
        {


            return RedirectToAction("Index", "Account",new { UserId = followeeId } );
        }
    }
}
