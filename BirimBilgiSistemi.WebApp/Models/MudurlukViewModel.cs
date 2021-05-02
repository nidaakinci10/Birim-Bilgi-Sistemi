using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class MudurlukViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Isim { get; set; }
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int BaskanlikId { get; set; }
        public  List<mudurluk> Mudurluks { get; set; }
        public virtual BaskanlikViewModel BaskanlikViewModel { get; set; }
        public int? PageNumber { get; set; }
        public int? PageSize { get; set; }

    }
}