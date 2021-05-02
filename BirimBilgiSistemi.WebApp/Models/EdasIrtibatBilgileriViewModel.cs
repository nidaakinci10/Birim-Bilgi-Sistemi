using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class EdasIrtibatBilgileriViewModel
    {
        public string isimSoyisim { get; set; }
        public string gorev { get; set; }
        public string unvani { get; set; }
        public string eposta { get; set; }
        public string telefon { get; set; }
        public string cepTelefon { get; set; }
        public List<edasIrtıbatBilgileri> EdasIrtıbatBilgileris { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}