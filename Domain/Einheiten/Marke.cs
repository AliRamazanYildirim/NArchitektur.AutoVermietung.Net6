using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Einheiten
{
    public class Marke:Einheit
    {
        public string Name { get; set; }
        public virtual ICollection<Modell> Modelle { get; set; }
        public Marke()
        {

        }

        public Marke(int id,string name):this()
        {
            Id = id;
            Name = name;
        }
    }
}
