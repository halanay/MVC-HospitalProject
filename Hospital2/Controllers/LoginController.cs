using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Identity;
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
        if (HttpContext.Session.GetInt32("UserId") != null)
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
        if (HttpContext.Session.GetInt32("UserId") != null)
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
            HttpContext.Session.SetInt32("UserId", UserFind.Id);
            HttpContext.Session.SetString("UserName", UserFind.UserName.ToString());
            if(UserFind.Role == "admin")
            {
                return RedirectToAction("UserList", "Admin");
            }
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
        if (HttpContext.Session.GetInt32("UserId") != null)
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
