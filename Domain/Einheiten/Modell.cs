using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Einheiten
{
    public class Modell:Einheit
    {
        public int MarkeId { get; set; }
        public string Name { get; set; }
        public decimal TagesPreis { get; set; }
        public string BildUrl { get; set; }
        public virtual Marke? Marke { get; set; }
        public Modell()
        {

        }

        public Modell(int id, int markeId, string name, decimal tagesPreis, string bildUrl) : this()
        {
            Id = id;
            MarkeId = markeId;
            Name = name;
            TagesPreis = tagesPreis;
            BildUrl = bildUrl;
            
            
        }
        

    }
}
