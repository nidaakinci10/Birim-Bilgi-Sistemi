using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("WebErisim")]
    public class webErisim:basicEntity
    {
        [DisplayName("Dağıtım Şirketi Id"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int dagitimSirketi_id { get; set; }

        [DisplayName ("Sorumlu İl Id")]
        public int sorumluIl_id { get; set; }

        [DisplayName (" VPN Kullanıcı Adı")]
        public string vpn_kullaniciAdi { get; set; }

        [DisplayName(" VPN Şifre")]
        public string vpn_sifre { get; set; }

        [DisplayName(" VPN Bağlantı Adresi")]
        public string vpn_baglantiAdresi { get; set; }

        [DisplayName(" VPN Uygulama Adı")]
        public string vpn_uygulamaAdi { get; set; }

        [DisplayName(" VPN IP")]
        public string IP { get; set; }

        [DisplayName(" WEB Kullanıcı Adı")]
        public string web_kullaniciAdi { get; set; }

        [DisplayName(" WEB Sifre")]
        public string web_sifre { get; set; }

        [DisplayName(" WEB Bağlantı Adresi")]
        public string web_baglantiAdresi { get; set; }

        [DisplayName("Genel Müdürlük Erişim Durumu")]
        public string erisimDurumuGM { get; set; }

        [DisplayName("Bölge Müdürlüğü Erişim Durumu")]
        public string erisimDurumuBM { get; set; }

        [DisplayName(" Açıklama")]
        public string aciklama { get; set; }

        [DisplayName(" Üstyazı")]
        public string  ustyazi { get; set; }

        public virtual edasBilgileri EdasBilgileri { get; set; }
    }
}