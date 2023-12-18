using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models
{
    public class AnaBilimDali
    {
        public int AnaBilimDaliId { get; set; }
        [Required]
        public int AnaBilimDaliName { get; set; }
        public List<Poliklinik> Polikliniks { get; } = new();
    }
}
