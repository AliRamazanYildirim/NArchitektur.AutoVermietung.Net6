using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Dynamik
{
    public class Sortieren
    {
        public string Feld { get; set; }
        public string Dir { get; set; }

        public Sortieren()
        {
        }

        public Sortieren(string feld, string dir)
        {
            Feld = feld;
            Dir = dir;
        }
    }
}
