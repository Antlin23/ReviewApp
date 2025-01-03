using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewApp.Entities;
using ReviewApp.ViewModels;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    [Authorize]
    public class ItemController : Controller {
        private readonly AppDbContext _appDbContext;

        public ItemController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IActionResult AddItem()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddItem(AddItemViewModel viewModel)
        {
            if (ModelState.IsValid) {
                try
                {
                    await _appDbContext.Items.AddAsync(viewModel);
                    await _appDbContext.SaveChangesAsync();
                }
                catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                    return View(viewModel);
                }

                return RedirectToAction("AddReview1", "Review");
            }
            return View(viewModel);
        }
    }
}
