using Core.Sicherheit.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.JWT
{
    public interface ITokenHelfer
    {
        ZugangsToken ErstelleToken(Benutzer benutzer, IList<OperationsAnspruch> operationsAnspruche);

        TokenAktualisieren ErstelleAktualisierrungsToken(Benutzer benutzer, string ipAdresse);
    }
}
