using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Verschlüsselung
{
    public class SicherheitsSchlüsselHelfer
    {
        public static SecurityKey ErstelleSicherheitsSchlüssel(string sicherheitsSchlüssel)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(sicherheitsSchlüssel));
        }
    }
}
