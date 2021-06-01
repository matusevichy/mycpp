using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnglishDictionary
{
    class App
    {
        private EnglishDictionary englishDictionary;
        public App()
        {
            englishDictionary = new EnglishDictionary();
            englishDictionary.Add("apple", "яблоко");
        }

        public void Start()
        {
            byte act;
            while (true)
            {
                MainMenu();
                byte.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case 1:
                        Console.WriteLine("Enter world:");
                        englishDictionary.FromEng(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case 2:
                        Console.WriteLine("Введите слово:");
                        englishDictionary.FromRus(Console.ReadLine());
                        Console.ReadKey();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }

        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select direction for translate:\n" +
                "1 - English to russian;\n" +
                "2 - Russian to english;\n" +
                "3 - Exit.\n");
        }
    }
}
