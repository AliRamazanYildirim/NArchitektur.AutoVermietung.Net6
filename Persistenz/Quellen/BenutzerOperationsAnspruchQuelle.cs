using Anwendung.Dienste.Quellen;
using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;
using Persistenz.Kontexte;

namespace Persistenz.Quellen
{
    public class BenutzerOperationsAnspruchQuelle : EfBasisQuelle<BenutzerOperationsAnspruch, BasisDbKontext>, IBenutzerOperationsAnspruchQuelle
    {
        public BenutzerOperationsAnspruchQuelle(BasisDbKontext context) : base(context)
        {
        }
    }
}
