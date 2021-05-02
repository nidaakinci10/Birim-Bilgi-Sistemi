using System;
using System.Collections.Generic;
using System.Text;

namespace BirimBilgiSistemi.DTO
{
   public class TakvimDTO
    {

        public int Id { get; set; }
        public int personel_id { get; set; }
        public string etkinlikAd { get; set; }
        public string etkinlikAciklama { get; set; }
        public string etkinlikKonum { get; set; }
        public int etkinlikKategori { get; set; }
        public DateTime baslangicTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }
        public string katilimci { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }
        public string Details { get; set; }


    }
}
