using Anwendung.Dienste.Quellen;
using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;
using Persistenz.Kontexte;

namespace Persistenz.Quellen
{
    public class OperationsAnspruchQuelle : EfBasisQuelle<OperationsAnspruch, BasisDbKontext>, IOperationsAnspruchQuelle
    {
        public OperationsAnspruchQuelle(BasisDbKontext context) : base(context)
        {
        }
    }
}
