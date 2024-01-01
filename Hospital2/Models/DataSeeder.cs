using Hospital2.Data;
namespace Hospital2.Models;

public static class DataSeeder
{
    public static void SeedData(ApplicationDbContext context)
    {
        // Seed data oluşturun
        var userData = new List<User>
        {
            new User
            {
                Email = "G221210301@sakarya.edu.tr",
                UserName = "G221210301@sakarya.edu.tr",
                Password = "sau",
                Cinsiyet = "Erkek",
                DogumTarihi = "01/01/1990",
                Adres = "123 Main St",
                Telefon = "1234567890",
                Boy = "175",
                Kilo = "70",
                Role = "admin"
            }
           
            // Diğer seed data örnekleri...
        };

        // Seed data'yı veritabanına ekleyin
        context.Users.AddRange(userData);
        context.SaveChanges();
    }
}

