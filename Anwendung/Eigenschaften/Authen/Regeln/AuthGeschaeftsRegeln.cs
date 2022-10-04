using Anwendung.Dienste.Quellen;
using Core.QuerSchnittsBedenken.Ausnahmen;
using Core.Sicherheit.Einheiten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Authen.Regeln
{
    public class AuthGeschaeftsRegeln
    {
        private readonly IBenutzerQuelle _benutzerQuelle;

        public AuthGeschaeftsRegeln(IBenutzerQuelle benutzerQuelle)
        {
            _benutzerQuelle = benutzerQuelle;
        }
        public async Task DieseEMailKannNichtWiederholtWerden(string email)
        {
            Benutzer? benutzer = await _benutzerQuelle.GeheZurAsync(b => b.Email == email);
            if (benutzer != null) throw new GeschaeflicheAusnahmen("E-Mail ist bereits vorhanden.");
        }
    }
}
