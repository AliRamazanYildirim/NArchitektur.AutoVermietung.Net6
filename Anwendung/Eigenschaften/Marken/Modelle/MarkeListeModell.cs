using Anwendung.Eigenschaften.Marken.Düoe;
using Core.Persistenz.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Marken.Modelle
{
    public class MarkeListeModell: PaginierbaresBasisModell
    {
        public IList<MarkeListeDüo> Element { get; set; }
    }
}
