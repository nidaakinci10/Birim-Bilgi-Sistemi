using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    public class basicEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime createdOn;
        [DisplayName("Kayıt Oluşturulma Tarihi"), ScaffoldColumn(false), Required]
        public DateTime CreatedOn
        {
            get { return DateTime.Now; }
            set { createdOn = value; }
        }
        public DateTime modifiedOn;
        [DisplayName("Kayıt Güncelleme Tarihi"), ScaffoldColumn(false), Required]
        public DateTime ModifiedOn
        {
            get { return DateTime.Now; }
            set { modifiedOn = value; }
        }

        [DisplayName("Kayıtı Güncelleyen Kullanıcı"), ScaffoldColumn(false), StringLength(30)]
        public string ModifiedUsername { get; set; }

    }
}