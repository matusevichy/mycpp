using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowFigures
{
    class FiguresCollection : IEnumerable
    {
        Figure[] figures;
        int count;
        public FiguresCollection(int capasity)
        {
            count = 0;
            figures = new Figure[capasity];
        }
        public void Add(Figure figure)
        {
            if(count<figures.Length)
            {
                figures[count++] = figure;
            }
            else
            {
                throw new Exception("Array is full");
            }
        }
        public void ShowAll()
        {
            Console.Clear();
            foreach (Figure item in figures)
            {
                if (item!=null)
                {
                    item.Show();
                
                }
            }
            Console.ReadKey();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return figures.GetEnumerator();
        }
    }
}
