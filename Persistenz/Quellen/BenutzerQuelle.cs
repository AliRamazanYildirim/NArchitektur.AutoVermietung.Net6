using Anwendung.Dienste.Quellen;
using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;
using Persistenz.Kontexte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistenz.Quellen
{
    public class BenutzerQuelle : EfBasisQuelle<Benutzer, BasisDbKontext>, IBenutzerQuelle
    {
        public BenutzerQuelle(BasisDbKontext context) : base(context)
        {
        }
    }
}
