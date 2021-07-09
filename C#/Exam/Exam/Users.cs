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
    class Users
    {
        private List<User> users;
        public User currentUser { get; set; }
        public Users()
        {
            users = new List<User>();
        }

        public void LoadData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("users.dat", FileMode.Open, FileAccess.Read))
            {
                users = binaryFormatter.Deserialize(fileStream) as List<User>;
            }
        }
        public void AddAdmin()
        {
            User user = new User
            {
                Id = 1,
                Login = "admin",
                Password = "Qwerty654321",
                Birth = DateTime.Parse("1990-01-01 00:00:00"),
                IsAdmin = true
            };
            users.Add(user);
            SaveData();
        }
        public bool Register()
        {
            string login, password;
            DateTime birth;
            Console.WriteLine("Enter login:");
            login = Console.ReadLine();
            Console.WriteLine("Enter password:");
            password = Console.ReadLine();
            Console.WriteLine("Enter birht date:");
            DateTime.TryParse(Console.ReadLine(), out birth);
            User user = new User
            {
                Id = users.Max(u => u.Id) + 1,
                Login = login,
                Password = password,
                Birth = birth,
                IsAdmin = false
            };
            var result = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if (!Validator.TryValidateObject(user, context, result, true))
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
                Console.ReadKey();
            }
            else
            {
                users.Add(user);
                return true;
            }
            return false;
        }
        public bool Login()
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
        public void SaveData()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("users.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, users);
            }
        }
        private void ShowUsersList()
        {
            users.ForEach(u => Console.WriteLine(u));
        }
        public User GetUserByID(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }
        public void EditUsers()
        {
            while (true)
            {
                Console.Clear();
                int act;
                ShowUsersList();
                Console.WriteLine("Select option:");
                Console.WriteLine("[1] - Delete user;");
                Console.WriteLine("[2] - Change IsAdmin for user;");
                Console.WriteLine("[3] - Change password for user;");
                Console.WriteLine("[4] - Exit to previous menu.");
                int.TryParse(Console.ReadLine(), out act);
                int id;
                User user;
                switch (act)
                {
                    case 1:
                        id = GetUserId();
                        users.RemoveAll(u => u.Id == id);
                        break;
                    case 2:
                        id = GetUserId();
                        user = users.FirstOrDefault(u => u.Id == id);
                        user.IsAdmin = !user.IsAdmin;
                        break;
                    case 3:
                        id = GetUserId();
                        user = users.FirstOrDefault(u => u.Id == id);
                        Console.WriteLine("Enter new password:");
                        string password = Console.ReadLine();
                        User newUser = new User
                        {
                            Id = user.Id,
                            Login = user.Login,
                            Password = password,
                            Birth = user.Birth,
                            IsAdmin = user.IsAdmin
                        };
                        var result = new List<ValidationResult>();
                        var context = new ValidationContext(newUser);
                        if (!Validator.TryValidateObject(newUser, context, result, true))
                        {
                            foreach (var item in result)
                            {
                                Console.WriteLine(item.ErrorMessage);
                            }
                            Console.ReadKey();
                        }
                        else
                        {
                            user.Password=password;
                        }
                        break;
                    case 4:
                        return;
                    default:
                        break;
                }
            }
        }
        private int GetUserId()
        {
            Console.WriteLine("Enter UserID:");
            int id;
            int.TryParse(Console.ReadLine(), out id);
            return id;
        }
    }
}
