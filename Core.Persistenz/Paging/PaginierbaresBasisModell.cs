using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Paging
{
    public class PaginierbaresBasisModell
    {
        int Index { get; }
        int Size { get; }
        int Zaehlen { get; }
        int Seiten { get; }
        bool HatVorheriges { get; }
        bool HatNaechstes { get; }
    }
}
