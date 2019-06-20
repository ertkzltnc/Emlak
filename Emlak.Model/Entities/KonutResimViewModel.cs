using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emlak.Model.Entities
{
    public class KonutResimViewModel
    {

        // Bir konutta bircok resim olma durumunda Controllde kullanılacak
        public Konut Konut { get; set; }
        public List<Fotograf> Fotograf { get; set; }
    }
}
