using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class EgitimBilgileriViewModel

    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int personelId { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string egitimTuru { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string okulAdi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string okulBolum { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string mezuniyetYili { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public List<egitimBilgileri> egitimBilgileris { get; set; }
        public virtual PersonelViewModel PersonelViewModel  { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}