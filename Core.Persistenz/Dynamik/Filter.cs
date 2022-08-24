using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Persistenz.Dynamik
{
    public class Filter
    {
        public string Feld { get; set; }
        public string Betreiber { get; set; }
        public string? Wert { get; set; }
        public string? Logik { get; set; }
        public IEnumerable<Filter>? Filters { get; set; }

        public Filter()
        {
        }

        public Filter(string feld, string @betreiber, string? wert, string? logik, IEnumerable<Filter>? filters) : this()
        {
            Feld = feld;
            Betreiber = @betreiber;
            Wert = wert;
            Logik = logik;
            Filters = filters;
        }
    }
}
