using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.ViewModels;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    [Authorize]
    public class ReviewController : Controller {
        private readonly AppDbContext _appDbContext;

        public ReviewController(AppDbContext context)
        {
            _appDbContext = context;
        }

        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview(AddReviewViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _appDbContext.Reviews.AddAsync(viewModel);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return View(viewModel);
                }

                return RedirectToAction("Index", "Home");
            }
            return View(viewModel);
        }
    }
}
