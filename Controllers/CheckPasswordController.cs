using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CyberDashboardProj.Controllers
{
    public class CheckPasswordController : Controller
    {
        private readonly IPasswordCheckerService _passwordCheckerService;

        public CheckPasswordController(IPasswordCheckerService passwordCheckerService)
        {
            _passwordCheckerService = passwordCheckerService;
        }

        // GET: PasswordChecker
        public IActionResult Index()
        {
            return View();
        }

        // POST: PasswordChecker/CheckPassword
        [HttpPost]
        public async Task<IActionResult> CheckPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                ViewBag.IsCompromised = null;
                return View("Index");
            }

            var isCompromised = await _passwordCheckerService.CheckPasswordAsync(password);
            ViewBag.IsCompromised = isCompromised;

            return View("Index");
        }
    }
}