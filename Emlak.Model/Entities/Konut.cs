using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("Konutlar")]
    public class Konut : BaseEntity<int>
    {
        public Konut()
        {
            this.Fotograflar = new HashSet<Fotograf>();
        }
        public short OdaSayisi { get; set; }
        public short BinaYasi { get; set; }
        public short BinaKat { get; set; }
        public short Kat { get; set; }
        public int Metrekare { get; set; }
        [Required]
        public string Aciklama { get; set; }
        [Required]
        public string Baslik { get; set; }
        public bool YayindaMi { get; set; }
        public decimal Fiyat { get; set; }
        [Required]
        public string Adres { get; set; }
        public int IlID { get; set; }
        [ForeignKey("IlID")]
        public virtual Il Il { get; set; }
        public int IlceID { get; set; }
        [ForeignKey("IlceID")]
        public virtual Ilce Ilce { get; set; }
        public int MahalleID { get; set; }
        [ForeignKey("MahalleID")]
        public virtual Mahalle Mahalle { get; set; }



        public int MusteriID { get; set; }
        [ForeignKey("MusteriID")]
        public virtual Musteri Musteri { get; set; }
        public int IlanTuruID { get; set; }
        [ForeignKey("IlanTuruID")]
        public virtual IlanTur IlanTur { get; set; }
        public int IsitmaTurID { get; set; }
        [ForeignKey("IsitmaTurID")]
        public virtual IsitmaTur IsitmaTur { get; set; }
        public ICollection<Fotograf> Fotograflar { get; set; }


    }
}
