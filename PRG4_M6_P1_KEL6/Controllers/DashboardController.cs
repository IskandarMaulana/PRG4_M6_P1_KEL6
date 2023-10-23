using Microsoft.AspNetCore.Mvc;

namespace PRG4_M5_P1_112.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
