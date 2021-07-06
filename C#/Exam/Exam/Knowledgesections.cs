using Exam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Exam
{
    class Knowledgesections
    {
        private List<Knowledgesection> knowledgesections;
        public Knowledgesections()
        {
            knowledgesections = new List<Knowledgesection>();
        }

        public void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Open, FileAccess.Read))
            {
                knowledgesections = binaryFormatter.Deserialize(fileStream) as List<Knowledgesection>;
            }
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, knowledgesections);
            }
        }

        public void Show()
        {
            knowledgesections.ForEach(k => Console.WriteLine(k));
        }

        public void Edit()
        {
            while (true)
            {
                Console.Clear();
                Show();
                int act;
                Console.WriteLine("Select option:");
                Console.WriteLine("[1] - Add record;");
                Console.WriteLine("[2] - Delete record;");
                Console.WriteLine("[3] - Exit to previos menu.");
                int.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case 1:
                        Console.WriteLine("Enter knowledge section name:");
                        string name = Console.ReadLine();
                        int idx;
                        if (knowledgesections.Count == 0)
                        {
                            idx = 1;
                        }
                        else
                        {
                            idx = knowledgesections.Max(k => k.Id) + 1;
                        }
                        Knowledgesection item = new Knowledgesection
                        {
                            Id = idx,
                            Name = name
                        };
                        knowledgesections.Add(item);
                        break;
                    case 2:
                        Console.WriteLine("Enter Id for delete record:");
                        int id;
                        int.TryParse(Console.ReadLine(), out id);
                        knowledgesections.RemoveAll(k => k.Id == id);
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
