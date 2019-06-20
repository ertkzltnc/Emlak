using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("Ilceler")]
    public class Ilce : BaseEntity2<int, string>
    {
        public Ilce()
        {
            this.Mahalleler = new HashSet<Mahalle>();
            this.Musteriler = new HashSet<Musteri>();
            this.EmlakOfisler = new HashSet<EmlakOfisi>();
            this.Konutlar = new HashSet<Konut>();
        }

        public int IlID { get; set; }
        public virtual Il Il { get; set; }

        public ICollection<Mahalle> Mahalleler { get; set; }
        public ICollection<Musteri> Musteriler { get; set; }
        public ICollection<Konut> Konutlar { get; set; }
        public ICollection<EmlakOfisi> EmlakOfisler { get; set; }

    }
}
