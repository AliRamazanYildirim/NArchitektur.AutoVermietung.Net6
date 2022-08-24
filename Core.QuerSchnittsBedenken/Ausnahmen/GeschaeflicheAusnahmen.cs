using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuerSchnittsBedenken.Ausnahmen
{
    public class GeschaeflicheAusnahmen : Exception
    {
        public GeschaeflicheAusnahmen(string nachricht) : base(nachricht)
        {
        }
    }
}
