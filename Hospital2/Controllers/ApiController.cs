using Hospital2.Data;
using Hospital2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Hospital2.Controllers
{
    public class ApiController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ApiController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Poliklinik()
        {
            
           // List<Poliklinik> poliklinikList = _db.AnaBilimDalis.ToList();
            List<Poliklinik> poliklinikList = _db.Polikliniks
    .Join(
        _db.AnaBilimDalis,
        poliklinik => poliklinik.AnaBilimDaliId,
        anaBilimDali => anaBilimDali.AnaBilimDaliId,
        (poliklinik, anaBilimDali) => new Poliklinik
        {
            PoliklinikId = poliklinik.PoliklinikId,
            PoliklinikIsmi = poliklinik.PoliklinikIsmi,
            AnaBilimDaliId = poliklinik.AnaBilimDaliId,
            AnaBilimDali = anaBilimDali
        }
    )
    .ToList();

            return Ok(poliklinikList);
        }
    }
}
