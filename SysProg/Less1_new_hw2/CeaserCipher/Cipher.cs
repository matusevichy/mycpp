using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeaserCipher
{
    public class Cipher
    {
        const int password = 5;
        public static string Encrypt(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] >= 65 && (int)text[i] <= 90)
                {
                    result += charEncrypt(65, 90, text[i]);
                }
                else if ((int)text[i] >= 97 && (int)text[i] <= 122)
                {
                    result += charEncrypt(97, 122, text[i]);
                }
                else if ((int)text[i] >= 1040 && (int)text[i] <= 1071)
                {
                    result += charEncrypt(1040, 1071, text[i]);
                }
                else if ((int)text[i] >= 1072 && (int)text[i] <= 1103)
                {
                    result += charEncrypt(1072, 1103, text[i]);
                }
                else result += text[i];
            }
            return result;
        }

        public static string Decrypt(string text)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if ((int)text[i] >= 65 && (int)text[i] <= 90)
                {
                    result += charDecrypt(65, 90, text[i]);
                }
                else if ((int)text[i] >= 97 && (int)text[i] <= 122)
                {
                    result += charDecrypt(97, 122, text[i]);
                }
                else if ((int)text[i] >= 128 && (int)text[i] <= 159)
                {
                    result += charDecrypt(128, 159, text[i]);
                }
                else if ((int)text[i] >= 160 && (int)text[i] <= 175)
                {
                    result += charDecrypt(97, 122, text[i]);
                }
                else if ((int)text[i] >= 224 && (int)text[i] <= 245)
                {
                    result += charDecrypt(224, 245, text[i]);
                }
                else result += text[i];
            }
            return result;
        }

        private static char charEncrypt(int min, int max, char symb)
        {
            var result = ((symb + password)<=max)? symb+ password:min+symb+password-max-1;
            return (char)result;
        }

        private static char charDecrypt(int min, int max, char symb)
        {
            var result = ((symb - password) >= min) ? symb - password : max + 1-symb+min-password;
            return (char)result;
        }
    }
}
