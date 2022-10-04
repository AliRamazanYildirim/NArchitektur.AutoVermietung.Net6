using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.Sicherheit.Hashing
{
    public class HashingHelfer
    {
        public static void ErstellePasswortHash(string passwort, out byte[] passwortHash, out byte[] passwortSalt)
        {
            using (HMACSHA512 hmac = new())
            {
                passwortSalt = hmac.Key;
                passwortHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwort));
            }
        }

        public static bool VerifizierePasswortHash(string passwort, byte[] passwortHash, byte[] passwortSalt)
        {
            using (HMACSHA512 hmac = new(passwortSalt))
            {
                byte[] berechneterHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwort));
                for (int i = 0; i < berechneterHash.Length; i++)
                    if (berechneterHash[i] != passwortHash[i])
                        return false;
            }

            return true;
        }
    }
}
