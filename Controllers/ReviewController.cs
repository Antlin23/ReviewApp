using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Services;
using ReviewApp.ViewModels;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    [Authorize]
    public class ReviewController : Controller {
        private readonly AppDbContext _appDbContext;
        private readonly ItemService _itemService;

        public ReviewController(AppDbContext appDbContext, ItemService itemService)
        {
            _appDbContext = appDbContext;
            _itemService = itemService;
        }

        public IActionResult AddReview1()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview1(AddReviewSearchItemViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    viewModel.SearchHits = await _itemService.SearchItemsAsync(viewModel);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    return View(viewModel);
                }
                return View(viewModel);
            }
            return View(viewModel);
        }

        public IActionResult AddReview2(string itemId)
        {
            ViewData["ItemId"] = itemId;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddReview2(AddReviewViewModel viewModel)
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
