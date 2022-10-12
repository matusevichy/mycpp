using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XorCipher
{
    public class Cipher
    {
        const int password = 15;
        public static string Encrypt(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                result += (char) (text[i] ^ password);
            }

            return result;
        }

        public static string Decrypt(string text)
        {
            string result = Encrypt(text);

            return result;
        }
    }
}
