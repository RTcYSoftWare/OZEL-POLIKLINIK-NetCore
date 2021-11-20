using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OzelPoliklinik.Database
{
    [Table("Admin")]
    public class Admin
    {
        [Key]
        public int Id { get; set; } = default(int);
        public string AdSoyad { get; set; }
        public Guid Anahtar { get; set; }
        public string Mail { get; set; }
        public string Sifre { get; set; }
        public DateTime OlusturulmaTarihi { get; set; }
        public DateTime GuncellenmeTarihi { get; set; }
        public bool ErisimYetkisi { get; set; }


    }
}
