using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Mudurluk")]
    public class mudurluk:basicEntity
    {
        [DisplayName("Müdürlük Adı"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string isim { get; set; }
        [DisplayName("Başkanlık Id"),Required(ErrorMessage = "{0} alanı gereklidir.")]
      
        public int baskanlikId { get; set; }
        public virtual List<seflik> Seflik { get; set; }
        public virtual List<personel> Personels { get; set; }
        public virtual baskanlik Baskanlik { get; set; }
       
        


    }
}