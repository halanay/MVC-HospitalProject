using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models
{
    public class AnaBilimDali
    {
        public int AnaBilimDaliId { get; set; }
        [Required]
        public string? AnaBilimDaliName { get; set; }
        public List<Poliklinik> Polikliniks { get; } = new();
    }
}
