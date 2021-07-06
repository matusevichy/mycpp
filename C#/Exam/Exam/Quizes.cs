using Exam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Exam
{
    class Quizes
    {
        private List<Knowledgesection> knowledgesections;
        private List<Quiz> quizes;
        private List<Answer> answers;
        public Quizes()
        {
            quizes = new List<Quiz>();
        }

        public void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Open, FileAccess.Read))
            {
                questions = binaryFormatter.Deserialize(fileStream) as List<Quiz>;
            }
            using (FileStream fileStream = new FileStream("answers.dat", FileMode.Open, FileAccess.Read))
            {
                answers = binaryFormatter.Deserialize(fileStream) as List<Answer>;
            }
            using (FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Open, FileAccess.Read))
            {
                knowledgesections = binaryFormatter.Deserialize(fileStream) as List<Knowledgesection>;
            }
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, questions);
            }
            using (FileStream fileStream = new FileStream("answers.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, answers);
            }
            using (FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, knowledgesections);
            }
        }

        public void ShowKnowledgeSections()
        {
            knowledgesections.ForEach(k => Console.WriteLine(k));
        }

        public void EditKnowledgeSections()
        {
            while (true)
            {
                Console.Clear();
                ShowKnowledgeSections();
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

        public void AddQuiz()
        {
            Console.WriteLine("");
        }

    }
}
