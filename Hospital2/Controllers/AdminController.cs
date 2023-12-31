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
        // *** Kullanıcı (Hasta) Liste Sayfası Başladı ***  
        public IActionResult UserList()
        {
            List<User> users = _db.Users.ToList();
            return View(users);
        }
        // *** Kullanıcı (Hasta) Liste Sayfası Bitti *** 

        // *** Kullanıcı(Hasta) Bilgilerini Güncelle/Ekle/Sil Başladı ***
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
        // *** Kullanıcı(Hasta) Bilgilerini Güncelle/Ekle/Sil Bitti ***


        // *** Doktor Liste Sayfası Başladı ***  
        public IActionResult DoktorList()
        {
            List<Doktor> doktors = _db.Doktors.ToList();
            return View(doktors);
        }
        // *** Doktor Liste Sayfası Bitti *** 

        // *** Doktor Bilgilerini Güncelle/Ekle/Sil Başladı ***
        public IActionResult DoktorEdit(int id)
        {
            Doktor doktoredit = _db.Doktors.FirstOrDefault(x => x.DoktorId == id);


            return View(doktoredit);
        }

        [HttpPost]
        public IActionResult DoktorEdit(Doktor updatedDoktor)
        {
            var existingDoktor = _db.Doktors.FirstOrDefault(d => d.DoktorId == updatedDoktor.DoktorId);

            if (existingDoktor != null)
            {
                // Doktoru güncelle
                existingDoktor.DoktarAdi = updatedDoktor.DoktarAdi;
                existingDoktor.Poliklinik = updatedDoktor.Poliklinik;  
                

                _db.SaveChanges();
            }
            return RedirectToAction("DoktorList", "Admin", new { id = updatedDoktor.DoktorId });
        }

        public IActionResult DoktorDelete(int id)
        {
            Doktor doktordelete = _db.Doktors.FirstOrDefault(x => x.DoktorId == id);

            _db.Doktors.Remove(doktordelete);
            _db.SaveChanges();

            return RedirectToAction("DoktorList", "Admin");
        }
        /*
        [HttpPost]
        public IActionResult DoktorCreate(Doktor yeniDoktor)
        {
            if (ModelState.IsValid)
            {
                _db.Doktors.Add(yeniDoktor);
                _db.SaveChanges();

                return RedirectToAction("DoktorList", "Admin");
            }

            // Eğer model doğrulama başarısız olursa, hata mesajlarıyla birlikte aynı sayfaya dönün
            return View(yeniDoktor);
        }
        */
        // *** Doktor Bilgilerini Güncelle/Ekle/Sil Bitti *** 

        // *** AnaBilimDali Liste Sayfası Başladı ***  
        public IActionResult AnaBilimDaliList()
        {
            List<AnaBilimDali> anabilimdali = _db.AnaBilimDalis.ToList();
            return View(anabilimdali);
        }
        // *** AnaBilimDali Liste Sayfası Bitti *** 

        // *** Anabilim Dalı Bilgilerini Güncelle/Ekle/Sil Başladı ***
        public IActionResult AnaBilimDaliEdit(int id)
        {
            AnaBilimDali anabilimdaliedit = _db.AnaBilimDalis.FirstOrDefault(x => x.AnaBilimDaliId == id);


            return View(anabilimdaliedit);
        }

        [HttpPost]
        public IActionResult AnaBilimDaliEdit(AnaBilimDali updatedAnabilimdali)
        {
            var existingAnabilimdali = _db.AnaBilimDalis.FirstOrDefault(a => a.AnaBilimDaliId == updatedAnabilimdali.AnaBilimDaliId);

            if (existingAnabilimdali != null)
            {
                // AnaBilimDali güncelle
                existingAnabilimdali.AnaBilimDaliName = updatedAnabilimdali.AnaBilimDaliName;
                


                _db.SaveChanges();
            }
            return RedirectToAction("AnaBilimDaliList", "Admin", new { id = updatedAnabilimdali.AnaBilimDaliId });
        }

        public IActionResult AnaBilimDaliDelete(int id)
        {
            AnaBilimDali anabilimdalidelete = _db.AnaBilimDalis.FirstOrDefault(x => x.AnaBilimDaliId == id);

            _db.AnaBilimDalis.Remove(anabilimdalidelete);
            _db.SaveChanges();

            return RedirectToAction("AnaBilimDaliList", "Admin");
        }
        /*
        [HttpPost]
        public IActionResult DoktorCreate(Doktor yeniDoktor)
        {
            if (ModelState.IsValid)
            {
                _db.Doktors.Add(yeniDoktor);
                _db.SaveChanges();

                return RedirectToAction("DoktorList", "Admin");
            }

            // Eğer model doğrulama başarısız olursa, hata mesajlarıyla birlikte aynı sayfaya dönün
            return View(yeniDoktor);
        }
        */
        // *** AnaBilimDali Bilgilerini Güncelle/Ekle/Sil Bitti *** 



        // *** Poliklinik Liste Sayfası Başladı ***  
        public IActionResult PoliklinikList()
        {
            List<Poliklinik> poliklinik = _db.Polikliniks.ToList();
            return View(poliklinik);
        }
        // *** Poliklinik Liste Sayfası Bitti *** 

        // *** Poliklinik Bilgilerini Güncelle/Ekle/Sil Başladı ***
        public IActionResult PoliklinikEdit(int id)
        {
            Poliklinik poliklinikedit = _db.Polikliniks.FirstOrDefault(x => x.PoliklinikId == id);


            return View(poliklinikedit);
        }

        [HttpPost]
        public IActionResult PoliklinikEdit(Poliklinik updatedPoliklinik)
        {
            var existingPoliklinik = _db.Polikliniks.FirstOrDefault(p => p.PoliklinikId == updatedPoliklinik.PoliklinikId);

            if (existingPoliklinik != null)
            {
                // Poliklinik güncelle
                existingPoliklinik.PoliklinikIsmi = updatedPoliklinik.PoliklinikIsmi;



                _db.SaveChanges();
            }
            return RedirectToAction("PoliklinikList", "Admin", new { id = updatedPoliklinik.PoliklinikId });
        }

        public IActionResult PoliklinikDelete(int id)
        {
            Poliklinik poliklinikdelete = _db.Polikliniks.FirstOrDefault(x => x.PoliklinikId == id);

            _db.Polikliniks.Remove(poliklinikdelete);
            _db.SaveChanges();

            return RedirectToAction("PoliklinikList", "Admin");
        }
        /*
        [HttpPost]
        public IActionResult DoktorCreate(Doktor yeniDoktor)
        {
            if (ModelState.IsValid)
            {
                _db.Doktors.Add(yeniDoktor);
                _db.SaveChanges();

                return RedirectToAction("DoktorList", "Admin");
            }

            // Eğer model doğrulama başarısız olursa, hata mesajlarıyla birlikte aynı sayfaya dönün
            return View(yeniDoktor);
        }
        */
        // *** Poliklinik Bilgilerini Güncelle/Ekle/Sil Bitti *** 



        // *** Admin Login Sayfası Başladı ***  
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
        // *** Admin Login Sayfası Bitti ***  

        // *** Admin Register Sayfası Başladı ***       
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
        // *** Admin Register Sayfası Bitti ***
    }
}
