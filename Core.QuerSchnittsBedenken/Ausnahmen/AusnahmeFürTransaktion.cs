using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.QuerSchnittsBedenken.Ausnahmen
{
    public class AusnahmeFürTransaktion : Exception
    {
        public  AusnahmeFürTransaktion(string nachricht) : base(nachricht)
        {
        }
    }
}
