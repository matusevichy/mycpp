using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowFigures
{
    class App
    {
        enum MenuItem
        {
            AddRectangle=1,
            AddTriangle=2,
            ShowAll=3,
            Exit=0
        }
        FiguresCollection figuresCollection;
        public App()
        {
            int length;
            Console.WriteLine("Enter capasity of the collection");
            Int32.TryParse(Console.ReadLine(), out length);
            figuresCollection = new FiguresCollection(length);
        }
        public void MainMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Select option:");
            Console.WriteLine("1 - Add rectangle");
            Console.WriteLine("2 - Add triangle");
            Console.WriteLine("3 - Show all figures");
            Console.WriteLine("0 - Exit.");
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
                    case (byte)MenuItem.AddRectangle:
                        {
                            Rectangle newFigure = new Rectangle();
                            newFigure.Set();
                            figuresCollection.Add(newFigure);
                            break;
                        }
                    case (byte)MenuItem.AddTriangle:
                        {
                            Triangle newFigure = new Triangle();
                            newFigure.Set();
                            figuresCollection.Add(newFigure);
                            break;
                        }
                    case (byte)MenuItem.ShowAll:
                        {
                            figuresCollection.ShowAll();
                            break;
                        }
                    case (byte)MenuItem.Exit:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
