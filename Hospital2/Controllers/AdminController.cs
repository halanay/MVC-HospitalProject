using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital2.Controllers
{
    public class AdminController : Controller
    {
        private readonly AplicationDbContext _db;

        public AdminController(AplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult UserList()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }

        public IActionResult UserEdit(int id)
        {
            User useredit = _db.Users.FirstOrDefault(x => x.Id == id);
            
            
            return View(useredit);
        }

        [HttpPost]
        public IActionResult UserEdit(User updatedUser)
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
            return RedirectToAction("UserList", "Admin", new { id = updatedUser.Id });
        }

        public IActionResult UserDelete(int id)
        {
            User userdelete = _db.Users.FirstOrDefault(x => x.Id == id);

            _db.Users.Remove(userdelete);
            _db.SaveChanges();

            return RedirectToAction("UserList", "Admin");
        }
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("AdminName") != null)
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
        public IActionResult Index(Admin admin)
        {
          /*  if (HttpContext.Session.GetInt32("AdminName") != null)
            {
                ViewBag.IsAuthenticated = true;
            }
            else
            {
                ViewBag.IsAuthenticated = false;
            }
          */

            var UserFind = _db.Admins.FirstOrDefault(a => a.AdminName == admin.AdminName && a.AdminPassword == admin.AdminPassword);
            if (UserFind != null)
            {
                HttpContext.Session.SetString("AdminName", UserFind.AdminName.ToString());
                return RedirectToAction("UserList", "Admin"); // ADmin Sayfasına Gider
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Yanlış Admin Bilgisi");
                return View("Index", admin);
            }


            
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(Admin admin)
        {
            if (ModelState.IsValid)
            {
                var newUser = new Admin
                {

                    //TC = user.TC,
                    AdminName = admin.AdminName,
                    AdminEmail = admin.AdminEmail,
                    AdminPassword = admin.AdminPassword,
                };

                _db.Admins.Add(newUser);
                _db.SaveChanges();

                return RedirectToAction("Login", "Admin");

            }
            return View();
        }
    }
}
