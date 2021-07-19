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
            ShowAllQuizes,
            CreateQuiz,
            EditQuiz,
            Exit
        }
        Users users;
        Quizes quizes;
        Knowledgesections knowledgesections;
        Results results;
        public App()
        {
            users = new Users();
            quizes = new Quizes();
            knowledgesections = new Knowledgesections();
            results = new Results();
            LoadData();
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
                                results.Add(users.currentUser, quizes.Run(users.currentUser, knowledgesections));
                                break;
                            case MenuAction.ViewHighscore:
                                results.ShowHighscoreTable(users);
                                break;
                            case MenuAction.ShowUsers:
                                users.EditUsers();
                                break;
                            case MenuAction.ShowKnowledge:
                                knowledgesections.Edit();
                                break;
                            case MenuAction.ShowAllQuizes:
                                quizes.ShowAll();
                                break;
                            case MenuAction.CreateQuiz:
                                quizes.Add(knowledgesections);
                                break;
                            case MenuAction.Exit:
                                SaveData();
                                return;
                            case MenuAction.EditQuiz:
                                quizes.Edit();
                                break;
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
                                results.Add(users.currentUser, quizes.Run(users.currentUser, knowledgesections));
                                break;
                            case MenuAction.ViewHighscore:
                                results.ShowHighscoreTable(users);
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
            quizes.LoadData();
            knowledgesections.LoadData();
            results.LoadData();
        }

        private void SaveData()
        {
            users.SaveData();
            quizes.SaveData();
            knowledgesections.SaveData();
            results.SaveData();
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
            Console.WriteLine("[8] - Exit.");
        }

        private void AdminMenu()
        {
            Console.Clear();
            Console.WriteLine("Select option:");
            Console.WriteLine("[1] - Run quiz;");
            Console.WriteLine("[2] - View highscore table;");
            Console.WriteLine("[3] - Show users list;");
            Console.WriteLine("[4] - Show knowledge sections list;");
            Console.WriteLine("[5] - Show all quizes;");
            Console.WriteLine("[6] - Create new quiz;");
            Console.WriteLine("[7] - Edit quiz;");
            Console.WriteLine("[8] - Exit.");
        }
    }
}
