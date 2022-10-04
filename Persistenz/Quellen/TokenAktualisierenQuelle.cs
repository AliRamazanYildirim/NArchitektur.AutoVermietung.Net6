using Anwendung.Dienste.Quellen;
using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;
using Persistenz.Kontexte;

namespace Persistenz.Quellen
{
    public class TokenAktualisierenQuelle : EfBasisQuelle<TokenAktualisieren, BasisDbKontext>, ITokenAktualisierenQuelle
    {
        public TokenAktualisierenQuelle(BasisDbKontext context) : base(context)
        {
        }
    }
}
