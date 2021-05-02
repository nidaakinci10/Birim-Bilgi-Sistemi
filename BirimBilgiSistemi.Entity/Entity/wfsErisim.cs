using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{

    [Table("WfsErisim")]

    public class wfsErisim:basicEntity
    {
        [DisplayName("Dağıtım Şirketi Id")]
        public int dagitimSirketi_id { get; set; }

        [DisplayName("VPN Kullanıcı Adı")]
        public string vpn_kullaniciAdi { get; set; }

        [DisplayName("VPN Sifre")]
        public string vpn_sifre { get; set; }

        [DisplayName("VPN Bağlantı Adresi")]
        public string vpn_baglantiAdresi { get; set; }

        [DisplayName("VPN Uygulama Adı")]
        public string vpn_uygulamaAdi { get; set; }

        [DisplayName("VPN IP")]
        public string vpn_IP { get; set;}

        [DisplayName("WFS Kullanıcı Adı")]
        public string wfs_kullaniciAdi{ get; set; }

        [DisplayName("WFS Sifre")]
        public string wfs_sifre { get; set; }

        [DisplayName("WFS Bağlantı Durumu")]
        public string wfs_baglantiAdresi { get; set; }

        [DisplayName("Erişim Durumu")]
        public string erisimDurumu { get; set; }

        [DisplayName("Açıklama")]
        public string aciklama { get; set; }


        public virtual edasBilgileri EdasBilgileri { get; set; }

    }
}