using Microsoft.AspNetCore.Mvc;

namespace MovieShop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
