using Microsoft.AspNetCore.Mvc;

namespace CyberDashboardProj.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
