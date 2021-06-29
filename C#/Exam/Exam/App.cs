using Exam.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Exam
{
    class App
    {
        private User currentUser;
        private List<Knowledgesection> knowledgesections;
        private List<Question> questions;
        private List<Answer> answers;
        private List<User> users;
        private List<Results> results;

        public App()
        {
//            currentUser = new User();
            knowledgesections = new List<Knowledgesection>();
            questions = new List<Question>();
            answers = new List<Answer>();
            users = new List<User>();
            results = new List<Results>();
            LoadData();
            if(users.Count==0)
            {
                AddAdmin();
            }
        }
        public void Start()
        {
            while (true)
            {
                int act;
                Console.Clear();
                if (currentUser == null)
                {
                    MainMenu();
                    int.TryParse(Console.ReadLine(), out act);
                    switch (act)
                    {
                        case 1:
                            Login();
                            break;
                        case 2:
                            Register();
                            break;
                        case 3:
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    if (currentUser.IsAdmin)
                    {
                        AdminMenu();
                        int.TryParse(Console.ReadLine(), out act);
                        switch (act)
                        {
                            case 1:
                                break;
                            case 2:
                                break;
                            case 3:
                                break;
                            case 4:
                                ShowKnowledgeSections();
                                AddKnowledgeSection();
                                break;
                            case 5:
                                break;
                            case 6:
                                break;
                            case 7:
                                return;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        UserMenu();
                        int.TryParse(Console.ReadLine(), out act);
                        switch (act)
                        {
                            case 1:
                                break;
                            case 2:
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

        private void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("users.dat", FileMode.Open, FileAccess.Read))
            {
                users = binaryFormatter.Deserialize(fileStream) as List<User>;
            }
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Open, FileAccess.Read))
            {
                questions = binaryFormatter.Deserialize(fileStream) as List<Question>;
            }
            using (FileStream fileStream = new FileStream("answers.dat", FileMode.Open, FileAccess.Read))
            {
                answers = binaryFormatter.Deserialize(fileStream) as List<Answer>;
            }
            using(FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Open, FileAccess.Read))
            {
                knowledgesections = binaryFormatter.Deserialize(fileStream) as List<Knowledgesection>;
            }
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Open, FileAccess.Read))
            {
                results = binaryFormatter.Deserialize(fileStream) as List<Results>;
            }
        }

        private void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("users.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream,users);
            }
            using (FileStream fileStream = new FileStream("questions.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, questions);
            }
            using (FileStream fileStream = new FileStream("answers.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream,answers);
            }
            using (FileStream fileStream = new FileStream("knowledgesections.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, knowledgesections);
            }
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, results);
            }
        }
        private bool Login()
        {
            string login, password;
            Console.Clear();
            Console.WriteLine("Enter login:");
            login = Console.ReadLine();
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();
            if ((currentUser = users.Find(u => u.Login == login && u.Password == password)) != null) return true;
            return false;
        }

        private void AddAdmin()
        {
            User user = new User
            {
                Id = users.Max(u => u.Id) + 1,
                Login = "admin",
                Password = "Qwerty654321",
                Birth = DateTime.Parse("1990-01-01 00:00:00"),
                IsAdmin = true
            };
            users.Add(user);
            SaveData();
        }
        
        private bool Register()
        {
            string login, password;
            DateTime birth;
            Console.WriteLine("Enter login:");
            login = Console.ReadLine();
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();
            DateTime.TryParse(Console.ReadLine(), out birth);
            User user = new User
            {
                Id = users.Max(u => u.Id)+1,
                Login = login,
                Password = password,
                Birth = birth,
                IsAdmin = false
            };
            var result = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user,context,result, true))
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            else
            {
                users.Add(user);
                return true;
            }
            return false;
        }

        private void ShowKnowledgeSections()
        {
            knowledgesections.ForEach(k => Console.WriteLine(k));
        }

        private void AddKnowledgeSection()
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
        private void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - LogIn;");
            Console.WriteLine("[2] - Register;");
            Console.WriteLine("[3] - Exit.");
        }
        
        private void UserMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Run quiz;");
            Console.WriteLine("[2] - View record table;");
            Console.WriteLine("[3] - Exit.");
        }

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Run quiz;");
            Console.WriteLine("[2] - View record table;");
            Console.WriteLine("[3] - Show users list;");
            Console.WriteLine("[4] - Show knowledge sections list;");
            Console.WriteLine("[5] - Show all qwizes;");
            Console.WriteLine("[6] - Create new qwiz;");
            Console.WriteLine("[7] - Exit.");
        }
    }
}
