using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class PersonelViewModel
    {
        public int id { get; set; }
        public List<personel> personels { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sicilNo { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string tcKimlik { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string ad { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string soyad { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string telefon { get; set; }
        public string dahili { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string eposta { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string meslegi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string unvani { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]

        public bool IsAdmin { get; set; }
        public string adres { get; set; }
        public int? BaskanlikId { get; set; }
        public int? MudurlukId { get; set; }
        public int? SeflikId { get; set; }
        public string kanGrubu { get; set; }
        public string yakininAdSoyadi { get; set; }
        public string yakininTelefon { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string Details { get; set; }
        //public string[] Action { get; set; }
     
        
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
        public virtual BaskanlikViewModel baskanlikViewModel { get; set; }
        public virtual MudurlukViewModel mudurlukViewModel { get; set; }
        public virtual SeflikViewModel seflikViewModel { get; set; }



       
    }
}