using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
   [Table("EdasIletisimBilgileri")]
    public class edasIletisimBilgileri:basicEntity
    {
        [DisplayName("Dağıtım Şirketi Id")]
        public int? dagitimSirketi_id { get; set; }
        public virtual edasBilgileri EdasBilgileri { get; set; }
        [DisplayName("Irtibat Personel Id")]
        public int? irtibatPersonel_id { get; set; }
        public virtual edasIrtıbatBilgileri EdasIrtıbatBilgileri { get; set; }
    }
}