using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("Iller")]
    public class Il : BaseEntity2<int, string>
    {
        public Il()
        {
            this.Ilceler = new HashSet<Ilce>();
            this.Musteriler = new HashSet<Musteri>();
            this.EmlakOfisler = new HashSet<EmlakOfisi>();
            this.Konutlar = new HashSet<Konut>();
        }
        public ICollection<Ilce> Ilceler { get; set; }
        public ICollection<Musteri> Musteriler { get; set; }
        public ICollection<Konut> Konutlar { get; set; }
        public ICollection<EmlakOfisi> EmlakOfisler { get; set; }

    }
}
