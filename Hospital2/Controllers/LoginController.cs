using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
public class LoginController : Controller
{
    public IActionResult Login()
    {
        return View();
    }
}
