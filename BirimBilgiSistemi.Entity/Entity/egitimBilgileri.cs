using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("EgitimBilgileri")]
    public class egitimBilgileri : basicEntity
    {

        [DisplayName("Personel ID"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int personelId { get; set; }
        [DisplayName ("Eğitim Türü"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string egitimTuru { get; set; }
        [DisplayName("Okul Adı"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string okulAdi { get; set; }
        [DisplayName("Okul Bölüm"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string okulBolum { get; set; }
        [DisplayName("Mezuniyet Yılı"),Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string mezuniyetYili { get; set; }
    }
}