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
    [Table("Musteriler")]
    public class Musteri : BaseEntity2<int, string>
    {
        public Musteri()
        {
            this.Konutlar = new HashSet<Konut>();
        }
        [Required]
        public string Soyad { get; set; }
        [Required]
        public string EvTelefonu { get; set; }
        //[Index(IsUnique = true)] // Uniq olması icin
        [Required]
        public string CepTelefonu { get; set; }
        [Required]
        public string AdresAyrinti { get; set; }
        [Required]
        public string Eposta { get; set; }
        public int IlID { get; set; }
        [ForeignKey("IlID")]
        public virtual Il Il { get; set; }
        public int IlceID { get; set; }
        [ForeignKey("IlceID")]
        public virtual Ilce Ilce { get; set; }
        public int MahalleID { get; set; }
        [ForeignKey("MahalleID")]
        public virtual Mahalle Mahalle { get; set; }
        public ICollection<Konut> Konutlar { get; set; }
    }
}
