using Anwendung.Dienste.Quellen;
using Core.Persistenz.Quellen;
using Domain.Einheiten;
using Persistenz.Kontexte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistenz.Quellen
{
    public class ModellQuelle : EfBasisQuelle<Modell, BasisDbKontext>, IModellQuelle
    {
        public ModellQuelle(BasisDbKontext context) : base(context)
        {
        }

    }
}
