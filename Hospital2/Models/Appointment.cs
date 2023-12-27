using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital2.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }


        [ForeignKey("Doktor")]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

      
        [ForeignKey("User")]
        public int Id { get; set; }
        public User User { get; set; }

        public int Date { get; set; }
        public int Hour { get; set; }

        

    }
}
