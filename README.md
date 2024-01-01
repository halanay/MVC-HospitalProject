1.	Proje Tanımı
Bu çalışma, Web Programlama dersi kapsamında yapılmıştır. Proje Asp.Net Core 6 MVC, C#, SQL Server, Entity Framework Core ORM, Bootstrap tema, HTML5, CSS3 ve Javascript teknolojileri kullanılarak geliştirilmiş bir web uygulamasıdır. Bu proje, kullanıcıların hastane randevularını online olarak alabilmelerini sağlamak amacıyla tasarlanmıştır. Proje, modern web geliştirme teknikleri ve en iyi uygulamalar kullanılarak oluşturulmuştur.

2.	Proje Giriş Bilgileri
Kullanıcı Girişi: https://localhost:7054/Login  bağlantısından Login sayfası üzerinde “Kullanıcı Adı” ve “Parola” bilgileri ile “Hastane Randevu Sistemi - Randevu Alma” paneline giriş yapılmaktadır. 
Yeni Kullanıcı Oluşturma: Login sayfasında yer alan “Kullanıcı Oluştur” düğmesi ile https://localhost:7054/register sayfasına gidilir ve yeni bir kullanıcı oluşturulur.
Admin Girişi: https://localhost:7054/Login  bağlantısından Login sayfası üzerinde “G221210301@sakarya.edu.tr” kullanıcı adı ve “sau” parolası ile “Hastane Randevu Sistemi - Admin” paneline giriş yapılmaktadır.
Api Hizmeti: https://localhost:7054/Api/Poliklinik bağlantısından Api hizmeti sağlanmaktadır.

3.	 Veritabanı Modeli
Projenin temel veritabanı modeli, SQL Server kullanılarak Entity Framework Core ORM ile oluşturulmuştur. Veritabanı şeması aşağıdaki gibidir:
Bu model, sistemin temel bileşenlerini ve ilişkilerini tanımlar.

4.	Sistem İşleyişi
4.1	Kullanıcı (Hasta) Paneli
Hastane Randevu Sistemi, kullanıcılara kayıt olma, giriş yapma, randevu alabilme, geçmiş ve gelecek randevularını görüntüleme, kişisel bilgilerini düzenleme gibi temel randevu sistemi fonksiyonlarını sunar. Ana sayfa, kullanıcıya anabilim dalı, poliklinik, doktor, tarih ve saat seçerek randevu oluşturma imkanı tanır. 
Kullanıcılar, doktorların çalışma gün ve saatlerini görebilir, uygun olan bir tarih ve saat seçerek randevu alabilirler. Randevular sayfasında geçmiş ve gelecek randevular listesi bulunur. Zamanı gelmemiş randevuları düzenleme ve silme fonksiyonu vardır. 
Sisteme giriş yapan kullanıcı, kişisel bilgiler sayfasından kendi bilgilerini düzenleyebilir.

4.2	Admin Paneli
Sistemin admin paneline giriş için aynı “Login” sayfası kullanılır. Bu sayfada kullanıcı adı kısmına “G221210301@sakarya.edu.tr” şifre kısmına “sau” yazarak admin girişi yapılır. Admin panelinde dört temel menü vardır. Bunlar: Kullanıcılar, Doktorlar, Anabilim Dalları, Poliklinikler şeklindedir. 
Kullanıcılar menüsü ana sayfa olup, bu sayfada kayıtlı kullanıcıların listesi yer almaktadır. Admin bu kullanıcılara ait bilgileri Güncelle/Sil butonları ile değiştirebilir ya da silebilir.
Doktorlar menüsüne tıklayınca sistemde kayıtlı doktorların listesi açılmaktadır. Mevcut doktorların bilgileri Güncelle/Sil butonları ile kontrol edilirken, Yeni Doktor Oluştur butonu ile yeni bir doktor kaydı oluşturulur. Bu sayfada doktorun polikliniği seçilmelidir.
Anabilim Dalları menüsünden anabilim dalı oluşturulurken, Poliklinik menüsünden poliklinik ismi ve hangi anabilim dalına ait ise seçilerek yeni bir poliklinik kaydı oluşturulur. 
Sistemde header’ın sağ bölümünde kullanıcının ismi ve çıkış yap butonu yer almaktadır. 


