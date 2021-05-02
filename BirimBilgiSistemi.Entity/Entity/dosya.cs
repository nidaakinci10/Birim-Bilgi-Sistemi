using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Dosya")]
    public class dosya:basicEntity
    {
        [DisplayName("Personel Id")]
        public int personel_id { get; set; }
        [DisplayName("Dosya Adı")]
        
        public string dosyaAdi { get; set; }
        [DisplayName("Dosya Açıklama")]
        public string dosyaAciklama { get; set; }
        [DisplayName("Dosya Path")]
        public string dosyaPath { get; set; }


        public virtual personel Personel { get; set; }

        //public virtual List<personel> PersonelList { get; set; }
    }
}