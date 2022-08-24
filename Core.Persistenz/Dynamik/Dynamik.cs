using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Dynamik
{
    public class Dynamik
    {
        public IEnumerable<Sortieren>? Sortieren { get; set; }
        public Filter? Filter { get; set; }

        public Dynamik()
        {
        }

        public Dynamik(IEnumerable<Sortieren>? sortieren, Filter? filter)
        {
            Sortieren = sortieren;
            Filter = filter;
        }
    }
}
