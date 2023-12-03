using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MP09.UF01.P01.Seguretat.Exemple.mp09.uf01.seguretat.exemple.model.security
{
    internal class MD5Security
    {
        internal string Encripta(string valorOriginal)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] dataBytes = Encoding.UTF8.GetBytes(valorOriginal);
                byte[] hashBytes = md5.ComputeHash(dataBytes);

                string hash = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hash;
            }
        }

    }
}
