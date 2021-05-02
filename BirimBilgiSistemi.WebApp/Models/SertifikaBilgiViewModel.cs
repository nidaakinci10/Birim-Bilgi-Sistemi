using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class SertifikaBilgiViewModel
    {
        [ Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int personelId { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaAdi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public DateTime sertifikaTarihi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaKurum { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sertifikaAciklama { get; set; }
        public List<sertifikaBilgi> SertifikaBilgis { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}