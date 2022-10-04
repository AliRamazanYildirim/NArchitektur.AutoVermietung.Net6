using Anwendung.Dienste.AuthDienst;
using Anwendung.Dienste.Quellen;
using Anwendung.Eigenschaften.Authen.Düoe;
using Anwendung.Eigenschaften.Authen.Regeln;
using Core.Sicherheit.Düoe;
using Core.Sicherheit.Einheiten;
using Core.Sicherheit.Hashing;
using Core.Sicherheit.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Eigenschaften.Authen.Befehle.Anmelden
{
    public class BefehlRegistrieren:IRequest<EingetragenDüo>
    {
        public BenutzerFürRegistrierungDüo BenutzerFürRegistrierungDüo { get; set; }
        public string IpAdresse { get; set; }
        public class BefehlsHandlerRegistrieren : IRequestHandler<BefehlRegistrieren, EingetragenDüo>
        {
            private readonly AuthGeschaeftsRegeln _authGeschaeftsRegeln;
            private readonly IBenutzerQuelle _benutzerQuelle;
            private readonly IAuthDienst _authDienst;

            public BefehlsHandlerRegistrieren(AuthGeschaeftsRegeln authGeschaeftsRegeln, 
                IBenutzerQuelle benutzerQuelle, IAuthDienst authDienst)
            {
                _authGeschaeftsRegeln = authGeschaeftsRegeln;
                _benutzerQuelle = benutzerQuelle;
                _authDienst = authDienst;
            }

            public async Task<EingetragenDüo> Handle(BefehlRegistrieren request, CancellationToken cancellationToken)
            {
                await _authGeschaeftsRegeln.DieseEMailKannNichtWiederholtWerden(request.BenutzerFürRegistrierungDüo.Email);
                byte[] passwortHash, passwortSalt;
                HashingHelfer.ErstellePasswortHash(request.BenutzerFürRegistrierungDüo.Passwort,
                    out passwortHash, out passwortSalt);
                Benutzer neuerBenutzer = new Benutzer()
                {
                    Email = request.BenutzerFürRegistrierungDüo.Email,
                    PasswortHash = passwortHash,
                    PasswortSalt = passwortSalt,
                    VorName = request.BenutzerFürRegistrierungDüo.VorName,
                    NachName = request.BenutzerFürRegistrierungDüo.NachName,
                    Status = true
                };
                Benutzer erstellteBenutzer = await _benutzerQuelle.InsertAsync(neuerBenutzer);

                ZugangsToken erstelltesZugangsToken = await _authDienst.ErstelleZugangsToken(erstellteBenutzer);

                TokenAktualisieren erstelltesAktualisierungsToken = await _authDienst.ErstelleAktualisierrungsToken
                    (erstellteBenutzer, request.IpAdresse);

                TokenAktualisieren hinzugefügtesAktualisierungsToken = await _authDienst.HinzufügeAktualisierrungsToken
                    (erstelltesAktualisierungsToken);

                EingetragenDüo eingetragenDüo = new()
                {
                    TokenAktualisieren = hinzugefügtesAktualisierungsToken,
                    ZugangsToken = erstelltesZugangsToken,
                };
                return eingetragenDüo;
            }
        }
    }
}
