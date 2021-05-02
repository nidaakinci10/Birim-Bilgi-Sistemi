using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class EdasIletisimBilgileriViewModel
    {
        public int? dagitimSirketi_id { get; set; }
        public int? irtibatPersonel_id { get; set; }
        public List<edasIletisimBilgileri> EdasIletisimBilgileris { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }
    }
}