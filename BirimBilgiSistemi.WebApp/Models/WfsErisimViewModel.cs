using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class WfsErisimViewModel
    {
        public int dagitimSirketi_id { get; set; }
        public string vpn_kullaniciAdi { get; set; }
        public string vpn_baglantiAdresi { get; set; }
        public string vpn_uygulamaAdi { get; set; }
        public string vpn_IP { get; set; }
        public string wfs_kullaniciAdi { get; set; }
        public string wfs_sifre { get; set; }
        public string wfs_baglantiAdresi { get; set; }
        public string erisimDurumu { get; set; }
        public string aciklama { get; set; }

        public List<wfsErisim> wfsErisims { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}