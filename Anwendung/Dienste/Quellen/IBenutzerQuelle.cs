using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Dienste.Quellen
{
    public interface IBenutzerQuelle:IAsyncQuelle<Benutzer>,IQuelle<Benutzer>
    {

    }
}
