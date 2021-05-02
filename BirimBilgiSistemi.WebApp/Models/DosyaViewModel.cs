using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class DosyaViewModel
    {
        public int personel_id { get; set; }
        public string dosyaAdi { get; set; }
        public string dosyaAciklama { get; set; }
        public string dosyaPath { get; set; }
        public List<dosya> dosyas { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}