using Microsoft.AspNetCore.Mvc;

public class CheckPasswordController : Controller
{
    private readonly PasswordService _passwordService;

    //public void PasswordController(PasswordService passwordService)
    //{
    //    _passwordService = passwordService;
    //}

    [HttpPost]
    public async Task<IActionResult> Index(string password)
    {
        bool isCompromised = await _passwordService.CheckIfPasswordCompromised(password);
        return View(new { IsCompromised = isCompromised });
    }
}