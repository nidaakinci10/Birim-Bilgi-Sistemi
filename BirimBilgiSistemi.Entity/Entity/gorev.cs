using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("Gorev")]
    public class gorev:basicEntity
    {
        [DisplayName ("Gorev isim")]
        public string isim  { get; set; }
        public bool ekleme { get; set; }
        public bool silme { get; set; }
        public bool duzenleme { get; set; }
        public bool goruntuleme { get; set; }
    }
}