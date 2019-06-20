using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Abstracts
{
    public abstract class BaseEntity<T>
    {

        // Her tablomuzda ki ID degerini BaseEntity den alacağız
        [Key]
        [Column(Order = 1)]
        public T ID { get; set; }
    }
}
