using Microsoft.AspNetCore.Mvc;
using ReviewApp.ViewModels;

namespace ReviewApp.Controllers {
    public class ItemController : Controller {
        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddItem(AddReviewViewModel viewModel)
        {
            return View();
        }
    }
}
