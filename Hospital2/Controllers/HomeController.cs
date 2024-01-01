using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

namespace Hospital2.Controllers;
public class HomeController : Controller
{

    private readonly ApplicationDbContext _db;

    public HomeController(ApplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {

        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;
        }
        else
        {
            ViewBag.IsAuthenticated = false;
            return RedirectToAction("index", "login");
        }
        var anabilimDallari = _db.AnaBilimDalis.ToList();
        ViewBag.AnaBilimDaliList = new SelectList(anabilimDallari, "AnaBilimDaliId", "AnaBilimDaliName");
        return View();
    }

    public IActionResult Randevularim()
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;

            var appointments = _db.Appointments
                .Where(a => a.UserId == HttpContext.Session.GetInt32("UserId"))
                .Join(_db.Doktors, a => a.DoktorId, d => d.DoktorId, (appointment, doctor) => new { Appointment = appointment, Doctor = doctor })
                .Join(_db.Polikliniks, d => d.Doctor.PoliklinikId, p => p.PoliklinikId, (d, poliklinik) => new AppointmentViewModel { Appointment = d.Appointment, Doktor = d.Doctor, Poliklinik = poliklinik })
                .OrderBy(a => a.Appointment.Date)
                .ToList();

            return View(appointments);

          
        }
        else
        {
            ViewBag.IsAuthenticated = false;
        }

        return View();

    }
    public IActionResult Profil(int id)
    {
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
            ViewBag.IsAuthenticated = true;
            User? user = _db.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null) {
                return View(user);
            }

        }
        else
        {
            ViewBag.IsAuthenticated = false;
        }
        return View();

    }


    // AJAX ile çağrılacak bir aksiyon
    public JsonResult GetPoliklinikList(int anaBilimDaliId)
    {
        var poliklinikler = _db.Polikliniks.Where(p => p.AnaBilimDaliId == anaBilimDaliId).ToList();
        return Json(new SelectList(poliklinikler, "PoliklinikId", "PoliklinikIsmi"));
    }

    // AJAX ile çağrılacak bir aksiyon
    public JsonResult GetDoktorList(int poliklinikId)
    {
        var doktorlar = _db.Doktors.Where(d => d.PoliklinikId == poliklinikId).ToList();
        return Json(new SelectList(doktorlar, "DoktorId", "DoktarAdi"));
    }


    public JsonResult GetAvailableHours(DateTime selectedDate, int doktorId)
    {
        var availableHours = _db.Appointments
            .Where(a => a.DoktorId == doktorId && a.Date == selectedDate)
            .Select(a => a.Hour.ToString("hh\\:mm"))
            .ToList();

        var allHours = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00"
    };
        var availableHoursList = allHours.Except(availableHours).ToList();
        return new JsonResult(availableHoursList);
    }


    [HttpPost]
    public ActionResult SaveAppointment(AppointmentModel appointmentModel)
    {
        var userId=0;
        if (HttpContext.Session.GetInt32("UserId") != null)
        {
             userId=Convert.ToInt32(HttpContext.Session.GetInt32("UserId"));
        }
        Appointment newAppointment = new()
        {
            Hour = appointmentModel.Hour,
            Date = appointmentModel.Date,
            DoktorId = appointmentModel.DoktorId,
            UserId = userId,
        };
        if (ModelState.IsValid)
        {
            // Model geçerliyse, veritabanına ekleme işlemini gerçekleştir
            _db.Appointments.Add(newAppointment);
            _db.SaveChanges();
            TempData["SuccessMessage"] = "Kayıt işlemi başarıyla tamamlandı.";
            return RedirectToAction("Index");
        }

        // Geçerli değilse, formu aynı sayfada tekrar gösterme
        return View("Index", appointmentModel);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
