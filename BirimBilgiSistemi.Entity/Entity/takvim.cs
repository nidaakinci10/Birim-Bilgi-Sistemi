using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Takvim")]
    public class takvim:basicEntity
    {
        [DisplayName("Personel Id")]
        public int personel_id { get; set; }
        [DisplayName("Etkinlik Adı"), StringLength(25, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır."), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikAd { get; set; }
        [DisplayName("Etkinlik Açıklama"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikAciklama { get; set; }
        [DisplayName("Etkinlik Konum"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikKonum { get; set; }
        [DisplayName("Etkinlik Kategori"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int etkinlikKategori { get; set;}
        [DisplayName("Başlangıç Tarihi"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime baslangicTarihi { get; set; }
        [DisplayName("Bitiş Tarihi"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime bitisTarihi { get; set; }
        [DisplayName("Katılımcılar"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string katilimci { get; set; }
        public virtual kategoriTipi kategoriTipi { get; set; }
        public virtual personel Personel { get; set; }
        public string NameSurname { get; set; }
        public override string ToString()
        {
            return NameSurname = Personel.ad + " " + Personel.soyad;
        }

    }
}