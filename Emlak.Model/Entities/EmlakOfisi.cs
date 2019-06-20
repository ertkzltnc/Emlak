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
    [Table("EmlakOfisleri")]
    public class EmlakOfisi : BaseEntity2<int, string>
    {
        [Required]
        public string AdresAyrinti { get; set; }
        [Required]
        public string Eposta { get; set; }
        [Required]
        public string CepTelefonu { get; set; }
        [Required]
        public string Fax { get; set; }
        //[Index(IsUnique = true)] // Unique olması icin 
        [Required]
        public string Yetkili { get; set; }
        [Required]
        public string Sifre { get; set; }
        public int IlID { get; set; }
        [ForeignKey("IlID")]
        public virtual Il Il { get; set; }

        public int IlceID { get; set; }
        [ForeignKey("IlceID")]
        public virtual Ilce Ilce { get; set; }
        public int MahalleID { get; set; }
        [ForeignKey("MahalleID")]
        public virtual Mahalle Mahalle { get; set; }
    }
}
