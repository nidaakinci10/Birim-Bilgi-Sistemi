using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class EdasBilgileriViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string dagitimSirketi { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string sorumluIl { get; set; }
        public string baglantiDurumu { get; set; }
        public string adres { get; set; }
        public string kepAdresi { get; set; }
    }
}