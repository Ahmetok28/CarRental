using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Constants
{
    public static class Messages
    {
        public static string SuccesfullyAdded = "Ekleme İşlemi Başarılı";
        public static string SuccesfullyUpdated = "Güncelleme İşlemi Başarılı";
        public static string SuccesfullyDeleted = "Silme İşlemi Başarılı";

       

        public static string InvalidName = "Eklemeye Çalıştığınız Nesnenin İsmi Geçersiz";

        public static string RentalDateisNull = "Arabanın kiralanabilmesi için arabanın teslim edilmesi gerekmektedir.";
        public static string AuthorizationDenied="yetkiniz yok";

        public static string UserRegistered = "Kayıt oldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Yanlış";
        public static string SuccessfulLogin = "Giriş Başrılı";
        public static string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static string AccessTokenCreated = "Token Oluşturuldu";

        public static string CarIsNotAvailable = "Girdiğiz Tarihler Arasında Araç Başka Bir Müşteride Kirada ";

        
        public static string PayIsSuccessfull = "Ödeme Başarılı";
        public static string CardInformationIsIncorrect = "Kart Bilgileri Hatalı";

        public static string CreditCardAdded = "Kredi Kartı Bilgileri Kaydedildi";
        public static string CreditCardDeleted = "Kredi Kartı Bilgileri Silindi";

        public static string NotFound = "İstediğiniz Nense Bulunmadı";

        public static string PaymentSuccessful = "Ödeme Başarılı";

        public static string EmailInvalid = "Geçersiz E-Posta Adresi";

        public static string AddRental = "Kiralama Başarılı";

        public static string RentalDateOk = "Araç Bu Tarihler Arasında kiralanabilir";
        public static string RentalReturnDateError = "Araç Bu Tarihler Arasında Başka Bir Müşteride Kirada";

        public static string BrandLimitExceded = "Marka Kayıt Limiti Aşıldı";
    }
}   
