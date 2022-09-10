using Anwendung.Eigenschaften.Marken.Düoe;
using Anwendung.Eigenschaften.Modelle.Düo;
using Core.Persistenz.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Modelle.Modelle
{
    public class ModellListeModell: PaginierbaresBasisModell
    {
        public IList<ModellListeDüo> Element { get; set; }
    }
}
