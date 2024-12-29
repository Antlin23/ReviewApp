using Microsoft.AspNetCore.Mvc;
using ReviewApp.Models;
using System.Diagnostics;

namespace ReviewApp.Controllers {
    public class HomeController : Controller {

        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
