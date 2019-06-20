using Emlak.Model.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    [Table("IsitmaTurleri")]
    public class IsitmaTur : BaseEntity2<int, string>
    {
        public IsitmaTur()
        {
            this.Konutlar = new HashSet<Konut>();
        }
        public ICollection<Konut> Konutlar { get; set; }
    }
}
