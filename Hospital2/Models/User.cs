using System.ComponentModel.DataAnnotations;

namespace Hospital.Models;

public class User
{
    public int Id { get; set; }
    [Required]
    public int Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; }

}
