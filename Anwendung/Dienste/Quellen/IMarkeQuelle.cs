using Core.Persistenz.Quellen;
using Domain.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Dienste.Quellen
{
    public interface IMarkeQuelle : IAsyncQuelle<Marke>, IQuelle<Marke>
    {
    }
}
