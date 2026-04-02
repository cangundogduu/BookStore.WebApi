using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
