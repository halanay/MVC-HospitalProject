using System.ComponentModel.DataAnnotations;

namespace Hospital2.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string UserName { get; set; }
    [Required]
    public string Password { get; set; } 
    public string Cinsiyet { get; set; } = string.Empty;
    public string DogumTarihi { get; set; } = string.Empty;
    public string Adres { get; set; } = string.Empty;
    public string Telefon { get; set; } = string.Empty;
    public string Boy { get; set; } = string.Empty;
    public string Kilo { get; set; } = string.Empty;

    public string Role { get; set; } = string.Empty;




}
