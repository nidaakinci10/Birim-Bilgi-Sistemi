using System;
using System.Collections.Generic;
using System.Text;

namespace BirimBilgiSistemi.DTO
{
    class SertifikaBilgileriDTO
    {
        public string sertifikaAdi { get; set; }
        public DateTime sertifikaTarihi { get; set; }
        public string sertifikaKurum { get; set; }
        public string sertifikaAciklama { get; set; }
    }
}
