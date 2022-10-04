using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Einheiten
{
    public class OperationsAnspruch:Einheit
    {
        public string Name { get; set; }

        public OperationsAnspruch()
        {
        }

        public OperationsAnspruch(int id,string name):base(id)
        {
            Name = name;
        }
    }
}
