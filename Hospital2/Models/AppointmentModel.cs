using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital2.Models
{
    public class AppointmentModel
    {
      
        public int DoktorId { get; set; }      
       
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public TimeSpan Hour { get; set; }       
    }
}
