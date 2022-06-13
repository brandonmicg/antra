using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
