using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Quellen
{
    public interface IAbfrage<T>
    {
        IQueryable<T> Abfrage();
    }
}
