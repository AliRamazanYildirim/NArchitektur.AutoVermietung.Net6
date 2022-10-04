using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.JWT
{
    public class ZugangsToken
    {
        public string Token { get; set; }
        public DateTime Ablauf { get; set; }
    }
}
