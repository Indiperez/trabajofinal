using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        // Acción para la página de inicio del dashboard
        public IActionResult Index()
        {
            return View();
        }
    }
}

