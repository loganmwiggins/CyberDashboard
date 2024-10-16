using Microsoft.AspNetCore.Mvc;

namespace CyberDashboardProj.Controllers
{
    public class AboutUsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
