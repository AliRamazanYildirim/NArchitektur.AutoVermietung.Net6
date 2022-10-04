using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Einheiten
{
    public class BenutzerOperationsAnspruch:Einheit
    {
        public int BenutzerId { get; set; }
        public int OperationsAnspruchId { get; set; }

        public virtual Benutzer Benutzer { get; set; }
        public virtual OperationsAnspruch OperationsAnspruch { get; set; }
    }
}
