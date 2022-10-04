using Anwendung.Dienste.Quellen;
using Core.Persistenz.Paging;
using Core.Sicherheit.Einheiten;
using Core.Sicherheit.JWT;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Anwendung.Dienste.AuthDienst
{
    public class AuthManager : IAuthDienst
    {
        private readonly IBenutzerOperationsAnspruchQuelle _benutzerOperationsAnspruchQuelle;
        private readonly ITokenHelfer _tokenHelfer;
        private readonly ITokenAktualisierenQuelle _tokenAktualisierenQuelle;

        public AuthManager(IBenutzerOperationsAnspruchQuelle benutzerOperationsAnspruchQuelle, ITokenHelfer tokenHelfer, 
            ITokenAktualisierenQuelle tokenAktualisierenQuelle)
        {
            _benutzerOperationsAnspruchQuelle = benutzerOperationsAnspruchQuelle;
            _tokenHelfer = tokenHelfer;
            _tokenAktualisierenQuelle = tokenAktualisierenQuelle;
        }

        public async Task<TokenAktualisieren> ErstelleAktualisierrungsToken(Benutzer benutzer,string ipAdresse)
        {
            TokenAktualisieren erstelleTokenAktualisieren = _tokenHelfer.
                ErstelleAktualisierrungsToken(benutzer, ipAdresse);
            return await Task.FromResult(erstelleTokenAktualisieren);
        }

        public async Task<ZugangsToken> ErstelleZugangsToken(Benutzer benutzer)
        {
            IPaginierung<BenutzerOperationsAnspruch> benutzerOperationsAnspruch = await _benutzerOperationsAnspruchQuelle.
                GeheZurListeAsync(b => b.BenutzerId == benutzer.Id,
                include: b => b.Include(b => b.OperationsAnspruch));
            IList<OperationsAnspruch>operationsAnspruch=benutzerOperationsAnspruch.Element.
                Select(b=>new OperationsAnspruch
                {
                Id = b.OperationsAnspruchId,
                    Name = b.OperationsAnspruch.Name
                }).ToList();

            ZugangsToken zugangsToken = _tokenHelfer.ErstelleToken(benutzer, operationsAnspruch);
            return zugangsToken;
        }

        public async Task<TokenAktualisieren> HinzufügeAktualisierrungsToken(TokenAktualisieren tokenAktualisieren)
        {
            TokenAktualisieren hinzuFügenTokenAktualisieren = await _tokenAktualisierenQuelle.
                InsertAsync(tokenAktualisieren);
            return hinzuFügenTokenAktualisieren;
        }

        

    }
}
