using Microsoft.AspNetCore.Mvc;

namespace CyberDashboardProj.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
