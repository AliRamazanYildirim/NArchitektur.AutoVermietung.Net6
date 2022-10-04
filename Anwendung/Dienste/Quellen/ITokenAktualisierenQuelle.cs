using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;

namespace Anwendung.Dienste.Quellen
{
    public interface ITokenAktualisierenQuelle : IAsyncQuelle<TokenAktualisieren>, IQuelle<TokenAktualisieren>
    {

    }
}
