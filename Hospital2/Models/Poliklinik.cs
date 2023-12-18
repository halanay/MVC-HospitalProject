using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital2.Models
{
    public class Poliklinik
    {
        public int PoliklinikId { get; set; }
        [Required]
        public string PoliklinikIsmi { get; set; }

        public List<Doktor> Doktors { get; set; }


        [ForeignKey("AnaBilimDali")]
        public int AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }


    }
}
