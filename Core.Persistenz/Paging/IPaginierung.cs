using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Paging
{
    public interface IPaginierung<T>
    {
        int From { get; }
        int Index { get; }
        int Grösse { get; }
        int Zaehlen { get; }
        int Seiten { get; }
        IList<T> Element { get; }
        bool HatVorherige { get; }
        bool HatNaechster { get; }
    }
}
