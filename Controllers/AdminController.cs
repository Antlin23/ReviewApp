using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ReviewApp.Controllers {
    //Should use role
    [Authorize]
    public class AdminController : Controller {
        public IActionResult Index()
        {
            return View();
        }
    }
}
