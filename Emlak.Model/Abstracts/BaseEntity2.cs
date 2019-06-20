using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Abstracts
{
    public abstract class BaseEntity2<T1, T2> : BaseEntity<T1>
    {
        // Bir cok tablomuzda Ad kolon degeri olacağı için base olarak tanımladık.
        [Required]
        public string Ad { get; set; }
    }
}
