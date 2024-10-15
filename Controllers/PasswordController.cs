//public class PasswordController : Controller
//{
//    private readonly PasswordService _passwordService;

//    public PasswordController(PasswordService passwordService)
//    {
//        _passwordService = passwordService;
//    }

//    [HttpPost]
//    public async Task<IActionResult> CheckPassword(string password)
//    {
//        bool isCompromised = await _passwordService.CheckIfPasswordCompromised(password);
//        return View(new { IsCompromised = isCompromised });
//    }
//}
