using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("EdasBilgileri")]
    public class edasBilgileri:basicEntity
    {
        [DisplayName("Dağıtım Şirketi"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string dagitimSirketi { get; set; }
        [DisplayName("Sorumlu İl"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sorumluIl { get; set; }
        [DisplayName("Bağlantı Durumu")]
        public string baglantiDurumu { get; set; }
        [DisplayName("Adres")]
        public string adres { get; set; }
        [DisplayName("KEP Adresi")]
        public string kepAdresi { get; set; }
         }
}