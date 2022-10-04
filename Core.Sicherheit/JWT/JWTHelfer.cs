using Core.Sicherheit.Einheiten;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.JWT
{
    public class JWTHelfer : ITokenHelfer
    {
        public IConfiguration Configuration { get; }
        private readonly TokenOptionen _tokenOptionen;
        private DateTime _ablaufZugangsToken;

        public JWTHelfer(IConfiguration configuration)
        {
            Configuration = configuration;
            //_tokenOptionen = Configuration.GetSection("TokenOptionen").Get<TokenOptionen>();
        }

        public TokenAktualisieren ErstelleAktualisierrungsToken(Benutzer benutzer, string ipAdresse)
        {
            throw new NotImplementedException();
        }

        public ZugangsToken ErstelleToken(Benutzer benutzer, IList<OperationsAnspruch> operationsAnspruche)
        {
            throw new NotImplementedException();
        }
    }
}
