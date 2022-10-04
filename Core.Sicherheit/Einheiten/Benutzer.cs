using Core.Sicherheit.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Einheiten
{
    public class Benutzer :Einheit
    {
        public string VorName { get; set; }
        public string NachName { get; set; }
        public string Email { get; set; }
        public byte[] PasswortSalt { get; set; }
        public byte[] PasswortHash { get; set; }
        public bool Status { get; set; }
        public AuthentifizierungsArt AuthentifizierungsArt { get; set; }
        public virtual ICollection<BenutzerOperationsAnspruch> BenutzerOperationsAnspruch { get; set; }
        public virtual ICollection<TokenAktualisieren> TokenAktualisieren { get; set; }

        public Benutzer()
        {
            BenutzerOperationsAnspruch = new HashSet<BenutzerOperationsAnspruch>();
            TokenAktualisieren = new HashSet<TokenAktualisieren>();
        }

        public Benutzer(int id,string vorName, string nachName, string email, byte[] passwortSalt,
            byte[] passwortHash, bool status, AuthentifizierungsArt authentifizierungsArt)
        {
            Id = id;
            VorName = vorName;
            NachName = nachName;
            Email = email;
            PasswortSalt = passwortSalt;
            PasswortHash = passwortHash;
            Status = status;
            AuthentifizierungsArt = authentifizierungsArt;
        }
    }
}
