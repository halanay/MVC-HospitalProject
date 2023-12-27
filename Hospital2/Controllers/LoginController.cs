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
        if (HttpContext.Session.GetString("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;
        }
        else
        {
            ViewBag.IsAuthenticated = false;
        }
        return View();

    }
    [HttpPost]
    public IActionResult Index(User user)
    {
        if (HttpContext.Session.GetString("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;
        }
        else
        {
            ViewBag.IsAuthenticated = false;
        }


        var UserFind = _db.Users.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
        if (UserFind != null)
        {
            HttpContext.Session.SetString("UserId", UserFind.Id.ToString());
            HttpContext.Session.SetString("UserName", UserFind.UserName.ToString());
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Yanlış Kullanıcı Bilgisi");
            return View("Index", user);
        }

    }
    public IActionResult LogOut()
    {

        HttpContext.Session.Remove("UserId");
        if (HttpContext.Session.GetString("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;
        }
        else
        {
            ViewBag.IsAuthenticated = false;
        }
        return RedirectToAction("Index", "Home");

    }
}
