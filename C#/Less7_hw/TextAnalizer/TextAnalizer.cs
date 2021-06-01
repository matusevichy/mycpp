using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextAnalizer
{
    class TextAnalizer
    {
        Dictionary<string, int> analiseResult;
        public TextAnalizer()
        {
            analiseResult = new Dictionary<string, int>();
        }

        public void Analize(string str)
        {
            List<string> list = str.Split(new char[] { '.', ',', '"', '\'', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var item in list)
            {
                if (analiseResult.ContainsKey(item))
                {
                    analiseResult[item] += 1;
                }
                else
                {
                    analiseResult.Add(item, 1);
                }
            }
        }
        public override string ToString()
        {
            string str=string.Empty;
            foreach (KeyValuePair<string,int> item in analiseResult)
            {
                str += $"{item.Key}: {item.Value}\n";
            }
            return str;
        }
    }
}
