using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    //codeFirst ile tablo ismini ve sütunlar oluşturuldu


    [Table("Personel")]
    public class personel : basicEntity
    {
        [DisplayName("Sicil Numarası"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string sicilNo { get; set; }
        [DisplayName("TC Kimlik Numarası"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string tcKimlik { get; set; }
        [DisplayName("Ad"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string ad { get; set; }
        [DisplayName("Soyad"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string soyad { get; set; }
        [DisplayName("Telefon"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string telefon { get; set; }
        [DisplayName("Dahili"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string dahili { get; set; }
        [DisplayName("E-Posta"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string eposta { get; set; }
        [DisplayName("Mesleği"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string meslegi { get; set; }
        [DisplayName("Unvanı"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string unvani { get; set; }
        [DisplayName("Yönetici mi?")]
        public bool IsAdmin { get; set; }
        [DisplayName("Adres"), Required(ErrorMessage = "{0} alanı boş geçilemez.")]
        public string adres { get; set; }


        //Baskanlık mudurluk seflik tablolarından çekilecek
        [DisplayName("baskanlık_id")]
        public int? baskanlikId { get; set; }
        [DisplayName("Mudurluk_id")]
        public int? mudurlukId{ get; set; }
        [DisplayName("seflik_id")]
        public int? seflikId { get; set; }
        [DisplayName("Kan Grubu")]
        public string kanGrubu { get; set; }
        [DisplayName("Yakınının Adı Soyadı")]
        public string yakininAdSoyadi{ get; set; }
        [DisplayName("Yakınının Telefonu")]
        public string yakininTelefon { get; set; }
        [DisplayName("Kullanıcı Adı")]
        public string kullanici_adi { get; set; }
        [DisplayName("Şifre")]
        public string sifre { get; set; }
        public List<takvim> Takvim { get; set; }
    }
}