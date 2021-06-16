using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDictionary
{
    class EnglishDictionary
    {
        private Dictionary<string, string> englDict;
        public EnglishDictionary()
        {
            englDict = new Dictionary<string, string>();
        }
        public void Add(string eng, string rus)
        {
            englDict.Add(eng, rus);
        }

        public void FromEng(string eng)
        {
            string rus;
            if(englDict.TryGetValue(eng, out rus))
            {
                Console.WriteLine($"English: {eng}, Russian: {rus}");
            }
            else
            {
                Console.WriteLine("This world not found in dictionary.");
            }
        }
        public void FromRus(string rus)
        {
            if(englDict.ContainsValue(rus))
            {
                foreach(var value in englDict)
                {
                    if (value.Value==rus)
                    {
                        Console.WriteLine($"Russian: {rus}, English: {value.Key}"); ;
                    }
                }
            }
            else
            {
                Console.WriteLine("Данное слово отсутствует в словаре.");
            }
        }
    }
}
