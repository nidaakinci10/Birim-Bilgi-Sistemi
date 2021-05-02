using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using BirimBilgiSistemi.Entity.Entity;
namespace BirimBilgiSistemi.WebApp.Models
{
    public class SeflikViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Isim { get; set; }
        public int? BaskanlikId { get; set; }
        public int? MudurlukId { get; set; }
        public List<seflik> Sefliks { get; set; }
        public virtual BaskanlikViewModel BaskanlikViewModel { get; set; }
        public virtual MudurlukViewModel MudurlukViewModel { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}