using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PRG4_M6_P1_KEL6.Models;
using System.Diagnostics;

namespace PRG4_M6_P1_KEL6.Controllers
{
    public class HomeController : Controller
    {
        private readonly Users _anggotaRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpPost]
        public IActionResult Login(string username, string password)
        {

            User anggotaModel = _anggotaRepository.getDataByUsername_Password(username, password);

            if (anggotaModel.Id == 0)
            {
                ViewBag.AlertMessage = "Username atau Password salah";
                return View("Index");
            }

            string serializedModel = JsonConvert.SerializeObject(anggotaModel);
            HttpContext.Session.SetString("Identity", serializedModel);
            return RedirectToAction("Index", "Home");
        }
    }
}