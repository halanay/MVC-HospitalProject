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
    public string Cinsiyet { get; set; }
    public string DogumTarihi { get; set; }
    public string Adres { get; set; }
    public string Telefon { get; set; }
    public string Boy { get; set; }
    public string Kilo { get; set; }




}
