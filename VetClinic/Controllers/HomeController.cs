using Microsoft.AspNetCore.Mvc;

namespace VetClinic.Controllers
{
    public class HomeController : Controller
    {
        // Acci�n para la p�gina de inicio del dashboard
        public IActionResult Index()
        {
            return View();
        }
    }
}

