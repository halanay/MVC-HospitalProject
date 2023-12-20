using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Controllers;
public class LoginController : Controller
{

    private readonly AplicationDbContext _db;

    public LoginController(AplicationDbContext db)
    {
        _db = db;
    }
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Index(User user)
    {
        var UserFind = _db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);

        if (UserFind != null) {
            return RedirectToAction("Index", "Home");
        }
        else {
            ModelState.AddModelError(string.Empty, "Yanlış Kullanıcı Bilgisi");
        return View("Index", user);
        }
        
    }
}
