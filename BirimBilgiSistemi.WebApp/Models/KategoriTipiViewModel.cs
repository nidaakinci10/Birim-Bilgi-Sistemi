using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class KategoriTipiViewModel
    {

        public int id { get; set; }
        public string KategoriTipi { get; set; }
        public string RenkKodu { get; set; }
        public virtual List<kategoriTipi> kategoriTipis { get; set; }
    }
}