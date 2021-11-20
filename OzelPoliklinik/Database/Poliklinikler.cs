using System;
using System.Collections.Generic;

#nullable disable

namespace OzelPoliklinik.Database
{
    public partial class Poliklinikler
    {
        public int Id { get; set; }
        public string KurulusAdi { get; set; }
        public string Sehir { get; set; }
        public string Ilce { get; set; }
        public string Adres { get; set; }
        public string Telefon { get; set; }
        public string Koordinat1 { get; set; }
        public string Koordinat2 { get; set; }
    }
}
