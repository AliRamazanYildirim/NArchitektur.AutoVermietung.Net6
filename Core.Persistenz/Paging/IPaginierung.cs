using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Paging
{
    public interface IPaginierung<T>
    {
        int Von { get; }
        int Index { get; }
        int Grösse { get; }
        int Zaehlen { get; }
        int Seiten { get; }
        IList<T> Element { get; }
        bool HatVorheriges { get; }
        bool HatNaechstes { get; }
    }
}
