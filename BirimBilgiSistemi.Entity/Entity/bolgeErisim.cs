using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BirimBilgiSistemi.Entity.Entity
{
    [Table("BolgeErisim")]
    public class bolgeErisim:basicEntity
    {
        [DisplayName("Bölge Müdürlüğü")]
        public string bolgeMudurlugu { get; set; }

        [DisplayName("İsim Soyisim")]
        public string isimSoyisim { get; set; }
        [DisplayName("Görev")]
        public string gorev { get; set; }
        [DisplayName("E-Posta")]
        public string eposta { get; set; }
        [DisplayName("Telefon")]
        public string telefon { get; set; }
        [DisplayName("Cep Telefonu")]
        public string cepTelefon { get; set; }
        [DisplayName("Erişim Durumu")]
        public string erisimDurumu { get; set; }
    }
}