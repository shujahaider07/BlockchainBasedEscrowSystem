using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace SignalRChat
{
    public class Hash
    {
    
        public static string Hash512(string password)
        {

            SHA512CryptoServiceProvider sHA512  = new SHA512CryptoServiceProvider();

            byte[]  Encode_byte = Encoding.ASCII.GetBytes(password);
            byte[] Compute_hash = sHA512.ComputeHash(Encode_byte);

            return Convert.ToBase64String(Compute_hash);



        }

    
    
    }
}