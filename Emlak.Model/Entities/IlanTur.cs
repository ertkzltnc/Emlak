using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("IlanTurleri")]
    public class IlanTur : BaseEntity2<int, string>
    {
        public IlanTur()
        {
            this.Konutlar = new HashSet<Konut>();
        }
        public ICollection<Konut> Konutlar { get; set; }
    }
}
