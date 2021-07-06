using Exam.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Exam
{
    class Results
    {
        private List<Result> results;
        public Results()
        {
            results = new List<Result>();
        }

        private void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Open, FileAccess.Read))
            {
                results = binaryFormatter.Deserialize(fileStream) as List<Result>;
            }
        }

        private void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, results);
            }
        }

        public void ShowHighscoreTable(Users users)
        {
            int idx = 0;
            var orderetResults = results.OrderBy(r => r.Points);
            foreach (var item in orderetResults)
            {
                Console.WriteLine($"{++idx}: {users.GetUserByID(item.UserId).Login}: {item.Points}");
            }
            Console.ReadKey();
        }

    }
}
