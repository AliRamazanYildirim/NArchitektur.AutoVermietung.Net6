using Core.Sicherheit.Einheiten;
using Core.Sicherheit.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Dienste.AuthDienst
{
    public interface IAuthDienst
    {
        public Task<ZugangsToken> ErstelleZugangsToken(Benutzer benutzer);
        public Task<TokenAktualisieren> ErstelleAktualisierrungsToken(Benutzer benutzer,string ipAdresse);
        public Task<TokenAktualisieren> HinzufügeAktualisierrungsToken(TokenAktualisieren tokenAktualisieren);

    }
}
