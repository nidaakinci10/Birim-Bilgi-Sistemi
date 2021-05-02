using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class WebErisimViewModel
    {
        public int dagitimSirketi_id { get; set; }
        public int sorumluIl_id { get; set; }
        public string vpn_kullaniciAdi { get; set; }
        public string vpn_sifre { get; set; }
        public string vpn_baglantiAdresi { get; set; }
        public string vpn_uygulamaAdi { get; set; }
        public string IP { get; set; }
        public string web_kullaniciAdi { get; set; }
        public string web_sifre { get; set; }
        public string web_baglantiAdresi { get; set; }
        public string erisimDurumuGM { get; set; }
        public string erisimDurumuBM { get; set; }
        public string aciklama { get; set; }
        public string ustyazi { get; set; }

        public List<webErisim> webErisims { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}