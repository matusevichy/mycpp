using Less11_hw.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Less11_hw
{
    class App
    {
        private List<User> users;

        public App()
        {
            users = new List<User>();
        }
        public void Start()
        {
            int act;
            while (true)
            {
                Menu();
                int.TryParse(Console.ReadLine(), out act);
                switch (act)
                {
                    case 1:
                        AddUser();
                        break;
                    case 2:
                        ShowAllUsers();
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
                Console.ReadKey();
            }
        }

        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Add user;");
            Console.WriteLine("[2] - Show list of the users");
            Console.WriteLine("[3] - Exit.");
        }

        private void ShowAllUsers()
        {
            foreach (var item in users)
            {
                Console.WriteLine(item);
            }
        }

        private void AddUser()
        {
            string firstName, lastName, patronym, country, city, passportSeries, passportNumber;
            DateTime birth;
            Console.WriteLine("Enter First name");
            firstName = Console.ReadLine();
            Console.WriteLine("Enter Last name");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter patronym");
            patronym = Console.ReadLine();
            Console.WriteLine("Enter date birth");
            DateTime.TryParse(Console.ReadLine(), out birth);
            Console.WriteLine("Enter country name");
            country = Console.ReadLine();
            Console.WriteLine("Enter city name");
            city = Console.ReadLine();
            Console.WriteLine("Enter passport series");
            passportSeries = Console.ReadLine();
            Console.WriteLine("Enter passport number");
            passportNumber = Console.ReadLine();
            Passport passport = new Passport 
                {
                Series = passportSeries,
                Number = passportNumber
            };
            User user = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Patronym = patronym,
                Birth = birth,
                Country = country,
                City = city,
                Passport = passport
            };
            var result = new List<ValidationResult>();
            var context = new ValidationContext(user);
            if(!Validator.TryValidateObject(user,context,result,true))
            {
                foreach (var item in result)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            else
            {
                users.Add(user);
            }
        }
    }
}
