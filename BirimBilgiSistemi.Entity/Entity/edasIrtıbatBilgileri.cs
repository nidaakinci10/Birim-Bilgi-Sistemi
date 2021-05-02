using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("EdasIrtibatPersonel")]
    public class edasIrtıbatBilgileri:basicEntity
    {
        [DisplayName("İsim Soyisim")]
        public string isimSoyisim { get; set; }

        [DisplayName("Gorev")]
        public string gorev { get; set; }
        [DisplayName("Unvanı")]
        public string unvani { get; set; }
        [DisplayName("E-Posta")]
        public string eposta { get; set; }
        [DisplayName("Telefon")]
        public string telefon { get; set; }
        [DisplayName("Cep Telefonu")]
        public string cepTelefon { get; set; }
    }
}