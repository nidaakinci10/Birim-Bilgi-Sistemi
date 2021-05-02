using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Baskanlik")]
    public class baskanlik: basicEntity
    {
        [DisplayName("Başkanlık Adı"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string isim { get; set; }
        public virtual List<mudurluk> Mudurluk { get; set; }
        public virtual List<seflik> Seflik { get; set; }
        public virtual List<personel> Personels { get; set; }

    }
}