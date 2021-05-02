using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class GorevViewModel
    {
        public string isim { get; set; }
        public List<gorev> gorevs { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}