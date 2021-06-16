using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student
{
    enum Subjects
    {
        Programming, Adminitstration, Design
    }
    class Student
    {
        public string FirstName { get; set; } = String.Empty;
        public string LastName { get; set; } = String.Empty;
        public string Patronymic { get; set; } = String.Empty;
        public string Group { get; set; } = String.Empty;
        public int Age { get; set; } = 0;
        public int[][] Grades { get; set; } = new int[3][];

        public void AddGrade(Subjects subj, int grade)
        {
            if (Grades[(int)subj] == null)
            {
                Grades[(int)subj] = new int[1];
            }
            else
            {
                Array.Resize<int>(ref Grades[(int)subj], Grades[(int)subj].Length + 1);
            }
                Grades[(int)subj][Grades[(int)subj].Length - 1] = grade;
        }

        public double? GetAverageBySubj(Subjects subj)
        {
            return Grades[(int)subj]?.Average() ?? 0;
        }

        public void Print()
        {
            Console.WriteLine($"Name: {FirstName} {Patronymic} {LastName}\n" +
                $"Group: {Group}\n" +
                $"Age: {Age}\n" +
                $"Grades:");
            foreach (int subj in Enum.GetValues(typeof(Subjects)))
            {
                Console.WriteLine(Enum.GetName(typeof(Subjects),subj));
                if (Grades[subj] != null)
                {
                    foreach (var item in Grades[subj])
                    {
                        Console.Write($"{item} ");
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
