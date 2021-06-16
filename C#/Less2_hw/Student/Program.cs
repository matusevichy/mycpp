using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/* 8.	Придумать класс, описывающий студента. Преду-
смотреть в нем следующие моменты: фамилия, имя,
отчество, группа, возраст, массив (зубчатый) оценок по
программированию, администрированию и дизайну.
А также добавить методы по работе с перечисленными 
данными: возможность установки/получения оцен-
ки, получение среднего балла по заданному предмету,
распечатка данных о студенте.*/

namespace Student
{
    class Program
    {
        static void Main(string[] args)
        {
            Student newStudent = new Student();
            newStudent.FirstName = "Vasya";
            newStudent.Patronymic = "Petrovich";
            newStudent.LastName = "Pupkin";
            newStudent.Group = "SPU21";
            newStudent.Age = 43;
            newStudent.AddGrade(Subjects.Adminitstration, 5);
            newStudent.AddGrade(Subjects.Adminitstration, 4);
            newStudent.AddGrade(Subjects.Adminitstration, 3);
            newStudent.AddGrade(Subjects.Programming, 2);
            newStudent.AddGrade(Subjects.Programming, 1);
            newStudent.AddGrade(Subjects.Design, 5);
            Console.WriteLine(newStudent.GetAverageBySubj(Subjects.Programming));
            newStudent.Print();
            Console.ReadKey();
        }
    }
}
