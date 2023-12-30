using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public IActionResult Index()
    {
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
        ModelState.Clear();
        //HttpContext.Session.SetString("UserId", user.Id.ToString());
        return View(user);
        
    }
    [HttpPost]
    public IActionResult ProfilUpdate(User updatedUser)
    {
        var existingUser = _db.Users.FirstOrDefault(u => u.Id == updatedUser.Id);

        if (existingUser != null)
        {
            // Kullanıcıyı güncelle
            existingUser.UserName = updatedUser.UserName;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
            existingUser.Cinsiyet = updatedUser.Cinsiyet;
            existingUser.Telefon = updatedUser.Telefon;
            existingUser.Adres = updatedUser.Adres;
            existingUser.DogumTarihi = updatedUser.DogumTarihi;
            existingUser.Boy = updatedUser.Boy;
            existingUser.Kilo = updatedUser.Kilo;

            _db.SaveChanges();
        }
        return RedirectToAction("Profil", "Home", new { id = updatedUser.Id });
    }


}
