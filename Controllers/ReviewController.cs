using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.ViewModels;

namespace ReviewApp.Controllers {
    [Authorize]
    public class ReviewController : Controller {
        public IActionResult AddReview()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddReview(AddReviewViewModel viewModel)
        {
            return View();
        }
    }
}
