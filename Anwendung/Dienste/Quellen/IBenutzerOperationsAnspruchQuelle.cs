using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;

namespace Anwendung.Dienste.Quellen
{
    public interface IBenutzerOperationsAnspruchQuelle : IAsyncQuelle<BenutzerOperationsAnspruch>, IQuelle<BenutzerOperationsAnspruch>
    {

    }
}
