using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Einheiten
{
    public class TokenAktualisieren:Einheit
    {
        public int BenutzerId { get; set; }
        public string Token { get; set; }
        public DateTime Ablauf { get; set; }
        public DateTime Erstellt { get; set; }
        public string ErstelltVonIp { get; set; }
        public DateTime? Widerrufen { get; set; }
        public string? WiderrufenVonIp { get; set; }
        public string? ErsetztDurchToken { get; set; }

        public string? GrundWiderrufen { get; set; }
        public virtual Benutzer Benutzer { get; set; }

        public TokenAktualisieren()
        {
        }

        public TokenAktualisieren(int id,string token, DateTime ablauf, DateTime erstellt, string erstelltVonIp,
            DateTime? widerrufen, string? widerrufenVonIp, string? ersetztDurchToken, string? grundWiderrufen)
        {
            Id = id;
            Token = token;
            Ablauf = ablauf;
            Erstellt = erstellt;
            ErstelltVonIp = erstelltVonIp;
            Widerrufen = widerrufen;
            WiderrufenVonIp = widerrufenVonIp;
            ErsetztDurchToken = ersetztDurchToken;
            GrundWiderrufen = grundWiderrufen;
        }
    }
}
