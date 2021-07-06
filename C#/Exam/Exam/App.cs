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
        enum MenuAction
        {
            RunQuiz = 1,
            ViewHighscore,
            ShowUsers,
            ShowKnowledge,
            ShowAllQwizes,
            CreateQwiz,
            Exit
        }
        Users users;
        Quizes quizes;
        private List<Results> results;

        public App()
        {
//            currentUser = new User();
            users = new Users();
            quizes = new Quizes();
            results = new List<Results>();
            LoadData();
            //if(users.Count==0)
            //{
            //    AddAdmin();
            //}
        }
        public void Start()
        {
            while (true)
            {
                int act;
                Console.Clear();
                if (users.currentUser == null)
                {
                    MainMenu();
                    int.TryParse(Console.ReadLine(), out act);
                    switch (act)
                    {
                        case 1:
                            users.Login();
                            break;
                        case 2:
                            users.Register();
                            break;
                        case 3:
                            return;
                        default:
                            break;
                    }
                }
                else
                {
                    if (users.currentUser.IsAdmin)
                    {
                        AdminMenu();
                        int.TryParse(Console.ReadLine(), out act);
                        switch ((MenuAction)act)
                        {
                            case MenuAction.RunQuiz:
                                break;
                            case MenuAction.ViewHighscore:
                                ShowHighscoreTable();
                                break;
                            case MenuAction.ShowUsers:
                                users.EditUsers();
                                break;
                            case MenuAction.ShowKnowledge:
                                quizes.EditKnowledgeSections();
                                break;
                            case MenuAction.ShowAllQwizes:
                                break;
                            case MenuAction.CreateQwiz:
                                break;
                            case MenuAction.Exit:
                                SaveData();
                                return;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        UserMenu();
                        int.TryParse(Console.ReadLine(), out act);
                        switch ((MenuAction)act)
                        {
                            case MenuAction.RunQuiz:
                                break;
                            case MenuAction.ViewHighscore:
                                ShowHighscoreTable();
                                break;
                            case MenuAction.Exit:
                                SaveData();
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
            users.LoadData();
            users.LoadData();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Open, FileAccess.Read))
            {
                results = binaryFormatter.Deserialize(fileStream) as List<Results>;
            }
        }

        private void SaveData()
        {
            users.SaveData();
            quizes.SaveData();
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = new FileStream("result.dat", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fileStream, results);
            }
        }

        private void ShowHighscoreTable ()
        {
            int idx = 0;
            var orderetResults = results.OrderBy(r => r.Points);
            foreach (var item in orderetResults)
            {
                Console.WriteLine($"{++idx}: {users.GetUserByID(item.UserId).Login}: {item.Points}");
            }
            Console.ReadKey();
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
            Console.WriteLine("[2] - View highscore table;");
            Console.WriteLine("[7] - Exit.");
        }

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Run quiz;");
            Console.WriteLine("[2] - View highscore table;");
            Console.WriteLine("[3] - Show users list;");
            Console.WriteLine("[4] - Show knowledge sections list;");
            Console.WriteLine("[5] - Show all qwizes;");
            Console.WriteLine("[6] - Create new qwiz;");
            Console.WriteLine("[7] - Exit.");
        }
    }
}
