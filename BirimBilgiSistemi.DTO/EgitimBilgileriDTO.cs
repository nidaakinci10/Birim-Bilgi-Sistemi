using System;
using System.Collections.Generic;
using System.Text;

namespace BirimBilgiSistemi.DTO
{
   public class EgitimBilgileriDTO
    {
        public int Id { get; set; }
        public int personelId { get; set; }
        public string egitimTuru { get; set; }
        public string okulAdi { get; set; }
        public string okulBolum { get; set; }
        public string mezuniyetYili { get; set; }
        public string Delete { get; set; }
        public string Update { get; set; }

    }
}
