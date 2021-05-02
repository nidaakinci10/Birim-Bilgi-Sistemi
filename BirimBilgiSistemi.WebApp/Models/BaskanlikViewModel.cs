using BirimBilgiSistemi.DTO;
using BirimBilgiSistemi.Entity.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.WebApp.Models
{
    public class BaskanlikViewModel
    {
        [Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string Ad { get; set; }
        public  List<baskanlik> Baskanliks { get; set; }
        public int? PageNumber  { get; set; }
        public int? PageSize { get; set; }
        //public List<BaskanlikViewModel> baskanlikViewModels { get; set; }
    }
}