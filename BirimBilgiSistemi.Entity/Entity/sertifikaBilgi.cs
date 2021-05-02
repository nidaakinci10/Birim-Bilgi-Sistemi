using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("SertifikaBigi")]
    public class sertifikaBilgi:basicEntity
    {

        [DisplayName("Personel ID"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int personelId { get; set; }
        [DisplayName("Sertifika Adı"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaAdi { get; set; }
        [DisplayName("Sertifika Tarihi"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime sertifikaTarihi {get; set; }
        [DisplayName("Sertifika Kurum"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaKurum { get; set; }
        [DisplayName("Sertifika Acıklama"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaAciklama { get; set; }

    }
}