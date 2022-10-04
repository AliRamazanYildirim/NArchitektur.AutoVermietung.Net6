using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.JWT
{
    public class TokenOptionen
    {
        public string Audienz { get; set; }
        public string Aussteller { get; set; }
        public int AblaufZugangsToken { get; set; }
        public string SicherheitsSchlüssel { get; set; }
        public int TokenTTLAktualisieren { get; set; }
    }
}
