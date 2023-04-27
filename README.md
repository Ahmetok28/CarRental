## (Geliştirmeye Devam Ediyorum...)
ArabaKiralamaProjesi
<ul>
  <li> Proje C# dilinde, çok katmanlı mimari ve SOLID prensiplerine uygun olarak geliştirildi. </li>
  <li> CRUD işlemleri Entity Framework kullanılarak gerçekleştirildi. </li>
  <li> Proje için MSSQL Localdb veritabanı kullanıldı. </li>
  <li> Bu sistem yetkilendirme ve doğrulama işlemleri içermektedir. </li>
  <li> Kullanıcılar yalnızca yetkilendirildikleri işlemleri gerçekleştirebilirler. </li>
  <li> JWT uygulamaları,Transaction, Cache, Validation and Performance aspectleri uygulandı. </li>
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
  <li> WebAPI : Projemizin Restful API Katmanıdır. Kullanılan yöntemler: Get, Post, Put, Delete. </li>
</ul>
Kullanılan Teknolojiler
<ul>
  <li> Restful API </li>
  <li> Result Types </li>
  <li> Interceptor </li>
  <li> Autofac </li>
  <li> AOP, Aspect Oriented Programming </li>
  <li> Caching </li>
  <li> Performance </li>
  <li> Transaction </li>
  <li> Validation </li>
  <li> Fluent Validation </li>
  <li> Cache Management </li>
  <li> JWT Authentication </li>
  <li> Repository Design Pattern </li>
  <li> Cross Cutting Concerns </li>
  <li> Extensions </li>
  <li> Claim </li>
  <li> Exception Middleware </li>
  <li> Service Collection </li>
  <li> Error Handling </li>
  <li> Validation Error Details </li>
 </ul>
