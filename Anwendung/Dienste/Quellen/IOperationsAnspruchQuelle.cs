using Core.Persistenz.Quellen;
using Core.Sicherheit.Einheiten;

namespace Anwendung.Dienste.Quellen
{
    public interface IOperationsAnspruchQuelle : IAsyncQuelle<OperationsAnspruch>, IQuelle<OperationsAnspruch>
    {

    }
}
