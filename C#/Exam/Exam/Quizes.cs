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
        private List<Question> questions;
        public Quizes()
        {
            questions = new List<Question>();
        }

        public void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Open, FileAccess.Read))
            {
                questions = binaryFormatter.Deserialize(fileStream) as List<Question>;
            }
        }

        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, questions);
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
            Question quiz = new Question
            {
                KnowledgesectionId = id,
                Text = qwestion,
                answers = answers
            };
            questions.Add(quiz);
        }

        public void ShowAll()
        {
            Console.Clear();
            Console.WriteLine("Quizes list:");
            questions.ForEach(q => Console.WriteLine(String.Join(' ', new String[] {"Index:", questions.IndexOf(q).ToString(), "\n", q.ToString() })) );
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
            Question quiz = questions[idx];
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
                Console.WriteLine($"{item.Text}, IsTrue: {item.IsTrue}");
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
            questions[idx] = quiz;
        }
        public int Run(User user, Knowledgesections knowledgesections)
        {
            int id;
            Console.WriteLine("Select knowledge section. Enter Id:");
            knowledgesections.Show();
            int.TryParse(Console.ReadLine(), out id);
            Console.ReadKey();
            var quiz = questions.Where(q => q.KnowledgesectionId == id).ToList();
            int counter = 0;
            int point = 0;
            foreach (var item in quiz)
            {
                if (counter<20)
                {
                    if (item.Run()) point++; ;
                    counter++;
                }
            }
            return point;
        }
    }
}
