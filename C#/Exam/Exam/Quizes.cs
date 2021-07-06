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


        public void AddQuiz()
        {
            Console.WriteLine("");
        }

    }
}
