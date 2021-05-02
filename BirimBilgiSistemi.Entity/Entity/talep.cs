using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Talep")]
    public class talep:basicEntity
    {
        [DisplayName("Personel Id"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public int personel_id { get; set; }
        [DisplayName("Talep Turu"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string talepTuru { get; set; }
        [DisplayName("eposta"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string eposta { get; set; }
        [DisplayName("Talep Açıklama"), Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string talepAciklama { get; set; }

        public virtual personel Personel { get; set; }


    }
}