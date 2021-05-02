using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("kategoriTipi")]
    public class kategoriTipi:basicEntity
    {
        [DisplayName("Kategori Türü"), StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string KategoriTipi { get; set; }
        [DisplayName("Kategori Türü Renk Kodu"), StringLength(50, ErrorMessage = "{0} alanı max.{1} karakter olmalıdır.")]
        public string RenkKodu { get; set; }
        public virtual List<takvim> Takvims { get; set; }
    }
}