using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Hospital2.Controllers;
public class HomeController : Controller
{

    private readonly AplicationDbContext _db;

    public HomeController(AplicationDbContext db)
    {
        _db = db;
    }
    public IActionResult Index()
    {
        var anabilimDallari = _db.AnaBilimDalis.ToList();
        ViewBag.AnaBilimDaliList = new SelectList(anabilimDallari, "AnaBilimDaliId", "AnaBilimDaliName");
        return View();
    }

    public IActionResult Randevularim()
    {

        return View();

    }
    public IActionResult Profil()
    {

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


        var availableHours = new List<string>
    {
        "08:00", "09:00", "10:00", "11:00", "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
    };

        return Json(availableHours);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
