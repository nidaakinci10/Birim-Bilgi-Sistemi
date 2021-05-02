using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class TalepViewModel
    {
        public int personel_id { get; set; }
        public string eposta { get; set; }
        public string talepAciklama { get; set; }
        public string talepTuru { get; set; }
        public List<talep> taleps { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}