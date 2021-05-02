using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class TakvimViewModel
    {
        
        public int personel_id { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikAd { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikAciklama { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string etkinlikKonum { get; set; }
        public int etkinlikKategori { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime baslangicTarihi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime bitisTarihi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string katilimci { get; set; }
        public List<takvim> takvims { get; set; }
        public virtual PersonelViewModel PersonelViewModel { get; set; }
        public virtual kategoriTipi  kategoriTipi{ get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }






        //takvim içine veri aktarmada kullanacağım parametreleri burada tanımladım
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string constraint { get; set; }
        public string color { get; set; }
        public string groupId { get; set; }
        public string NameSurname { get; set; }
        
    }
}