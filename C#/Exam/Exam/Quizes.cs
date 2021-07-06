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
        private List<Quiz> quizes;
        public Quizes()
        {
            quizes = new List<Quiz>();
        }

        public void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("quizes.dat", FileMode.Open, FileAccess.Read))
            {
                quizes = binaryFormatter.Deserialize(fileStream) as List<Quiz>;
            }
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("quizes.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, quizes);
            }
        }


        public void Add(Knowledgesections knowledgesections)
        {
            Console.Clear();
            int id;
            knowledgesections.Show();
            Console.WriteLine("Select knowledgesection id:");
            int.TryParse(Console.ReadLine(), out id);
            Console.WriteLine("Enter question:");
            string qwestion = Console.ReadLine();
            List<Answer> answers = new List<Answer>();
            bool isTrue;
            bool next = true;
            while (next)
            {
                Console.WriteLine("Enter answer:");
                string answer = Console.ReadLine();
                Console.WriteLine("This answer is true?(y/n)");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        isTrue = true;
                        break;
                    case ConsoleKey.N:
                        isTrue = false;
                        break;
                    default:
                        isTrue = false;
                        break;
                }
                answers.Add(new Answer { Text = answer, IsTrue = isTrue });
                Console.WriteLine("Next answer?(y/n)");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        next = true;
                        break;
                    case ConsoleKey.N:
                        next = false;
                        break;
                    default:
                        next = false;
                        break;
                }
            }
            Quiz quiz = new Quiz
            {
                KnowledgesectionId = id,
                Text = qwestion,
                answers = answers
            };
            quizes.Add(quiz);
        }

        public void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Quizes list:");
            quizes.ForEach(q => Console.WriteLine(String.Join(' ', new String[] {"Index:", quizes.IndexOf(q).ToString(), "\n", q.ToString() })) );
            Console.ReadKey();
        }

        public void Edit()
        {
            ShowAll();
            Console.WriteLine("Enter the index of the quiz for edit");
            int idx;
            int.TryParse(Console.ReadLine(), out idx);
            EditById(idx);
        }

        public void EditById(int idx)
        {
            Quiz quiz = quizes[idx];
            Console.WriteLine("Question:");
            Console.WriteLine(quiz.Text);
            Console.WriteLine("Enter new text of question or press Enter for skip this step:");
            string text = Console.ReadLine();
            if (text != "")
            {
                quiz.Text = text;
            }
            foreach (var item in quiz.answers)
            {
                Console.WriteLine("Answers:");
                Console.WriteLine(item.Text);
                Console.WriteLine("Enter new text of question or press Enter for skip this step:");
                text = Console.ReadLine();
                if (text != "")
                {
                    item.Text = text;
                }
                Console.WriteLine("This answer is true?(y/n)");
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.Y:
                        item.IsTrue = true;
                        break;
                    case ConsoleKey.N:
                        item.IsTrue = false;
                        break;
                    default:
                        break;
                }
            }
            quizes[idx] = quiz;
        }
    }
}
