using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
[Table("Seflik")]
    public class seflik:basicEntity
    {
        [DisplayName("Şeflik Adı"),Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string isim { get; set; }
        [DisplayName("Başkanlık Id")]
        public int? BaskanlikId { get; set; }
        [DisplayName("Mudurluk Id")]
        public int? MudurlukId { get; set; }
        public virtual baskanlik Baskanlik { get; set; }

        public virtual mudurluk Mudurluk { get; set; }
  
        public List<personel> Personels { get; set; }
    }
}