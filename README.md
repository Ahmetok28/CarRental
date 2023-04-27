## (Geliştirmeye Devam Ediyorum...)
ArabaKiralamaProjesi
<ul>
  <li> Proje C# dilinde, çok katmanlı mimari ve SOLID prensiplerine uygun olarak geliştirildi. </li>
  <li> CRUD işlemleri Entity Framework kullanılarak gerçekleştirildi. </li>
  <li> Proje için MSSQL Localdb veritabanı kullanıldı. </li>
  <li> Bu sistem yetkilendirme ve doğrulama işlemleri içermektedir. </li>
  <li> Kullanıcılar yalnızca yetkilendirildikleri işlemleri gerçekleştirebilirler. </li>
  <li> JWT uygulamaları, İşlem, Önbellek, Doğrulama ve Performans yönleri uygulandı. </li>
  <li> Doğrulama için Fluent Validation desteği, IoC için Autofac desteği eklendi. </li>
  <li> Proje, araba, marka, renk, araba resimleri, kullanıcı, işlem talebi, kullanıcı işlem talepleri, müşteri, kredi kartı ve kiralama için CRUD işlemleri içerir. </li>
  <li> Araba kiralama belirli iş kurallarına göre gerçekleştirilir. </li>
</ul>
Katmanlar
<ul>
  <li> Core : Projenin evrensel işlemleri için kullanılan çekirdek katmanıdır. </li>
  <li> DataAccess : Projenin veritabanı ile bağlantı kurduğu katmandır. </li>
  <li> Entities: Veritabanındaki tablolarımız, projemizdeki nesneler olarak oluşturulmuştur. DTO nesnelerini de içerir. </li>
  <li> Business : Projemizin iş katmanıdır. Çeşitli iş kuralları; Veri kontrolleri, doğrulamalar ve yetkilendirme kontrolleri içerir. </li>
  <li> WebAPI : Projemizin Restful API Katmanıdır. Bilinen yöntemler: Get, Post, Put, Delete. </li>
</ul>
Kullanılan Teknolojiler
<ul>
  <li> Restful API </li>
  <li> Sonuç Türleri </li>
  <li> Interceptor </li>
  <li> Autofac </li>
  <li> AOP, Aspect Oriented Programming </li>
  <li> Önbellekleme </li>
  <li> Performans </li>
  <li> İşlem </li>
  <li> Doğrulama </li>
  <li> Fluent Validation </li>
  <li> Önbellek Yönetimi </li>
  <li> JWT Kimlik Doğrulama </li>
  <li> Repository Tasarım Deseni </li>
  <li> Kesintisiz Konular </li>
  <li> Uzantılar </li>
  <li> İşlem Talebi </li>
  <li> İstisna Aracı </li>
  <li> Hizmet Koleksiyonu </li>
