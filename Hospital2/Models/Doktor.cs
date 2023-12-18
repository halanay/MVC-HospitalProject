using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models
{
    public class Doktor
    {

        public int DoktorId { get; set; }
        [Required]
        public string DoktarAdi { get; set; }


        [ForeignKey("Poliklinik")]
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }
    }
}
