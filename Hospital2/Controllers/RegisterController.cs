using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;



namespace Hospital2.Controllers;
public class RegisterController : Controller
{




    private readonly AplicationDbContext _db;
    
    public RegisterController(AplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult Index() {
        return View();
    }
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public IActionResult Index(User user)
	{
        if (ModelState.IsValid)
        {
           var newUser = new User
                {
                    
                    //TC = user.TC,
                    UserName = user.UserName,
                    Email = user.Email,
                    Password = user.Password,
                };

                _db.Users.Add(newUser);
                _db.SaveChanges();

            return RedirectToAction("Index", "Home");

        }

        //HttpContext.Session.SetString("UserId", user.Id.ToString());
        return View(user);
        ModelState.Clear();
    }
}
