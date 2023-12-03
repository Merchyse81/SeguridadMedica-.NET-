using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MP09.UF01.P01.Seguretat.Exemple.mp09.uf01.seguretat.exemple.model.security
{
    internal class SHA256Security
    {
        internal string Encripta(string valorOriginal)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(valorOriginal);
                byte[] hashBytes = sha256.ComputeHash(dataBytes);

                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
