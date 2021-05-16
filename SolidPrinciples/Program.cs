using System;
using System.Collections.Specialized;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;

namespace SolidPrinciples
{
    class Program
    {
        static readonly string[] view = { "Add Students", "View Students", "Quit" };
        static readonly string[] time = { "Full Time", "Distance", "Back" };
        static readonly string filename = "students.txt";

        static void Main(string[] args)
        {
            StudentFile studentFile = new(filename);
            ListStorage.SetStudents(studentFile.ReadText());
            MainMenu();
        }

        static void MainMenu()
        {
            int selection = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO OUR UNIVERSITY DASHBOARD");
                Console.WriteLine("Use the Arrows to navigate through the menu");
                for (int i = 0; i < view.Length; i++)
                {
                    if (selection == i)
                    {
                        Console.Write(view[i].PadRight(35));
                        Console.WriteLine("CURRENTLY SELECTED");
                    }
                    else
                    {
                        Console.WriteLine(view[i]);
                    }
                }
                key = Console.ReadKey(true);
                if (key.Key.ToString() == "DownArrow")
                {
                    selection++;
                    if (selection > view.Length - 1)
                    {
                        selection = 0;
                    }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = view.Length - 1;
                    }
                }
            } 
            while (key.KeyChar != 13);

            switch (selection)
            {
                case 0:
                    AddStudentMenu();
                    break;
                case 1:
                    ViewStudents();
                    break;
                case 2:
                    Console.Clear();
                    break;
                default:
                    break;
            }
        }
        static void AddStudentMenu()
        {
            int selection = 0;
            ConsoleKeyInfo key;
            do
            {
                Console.Clear();
                Console.WriteLine("Use the Arrows to navigate through the menu");
                for (int i = 0; i < time.Length; i++)
                {
                    if (selection == i)
                    {
                        Console.Write(time[i].PadRight(35));
                        Console.WriteLine("CURRENTLY SELECTED");
                    }
                    else
                    {
                        Console.WriteLine(time[i]);
                    }
                }
                key = Console.ReadKey(true);
                if (key.Key.ToString() == "DownArrow")
                {
                    selection++;
                    if (selection > time.Length - 1)
                    {
                        selection = 0;
                    }
                }
                else if (key.Key.ToString() == "UpArrow")
                {
                    selection--;
                    if (selection < 0)
                    {
                        selection = time.Length - 1;
                    }
                }
            } 
            while (key.KeyChar != 13);
            if (selection != 2)
            {
                AddStudent(selection);
            }
            else
            {
                MainMenu();
            }
        }

        static void AddStudent(int selection)
        {
            Console.Write("STUDENT ID     : ");
            string id = Console.ReadLine();
            Console.Write("FIRST NAME     : ");
            string firstName = Console.ReadLine();
            Console.Write("LAST NAME      : ");
            string lastName = Console.ReadLine();

            StudentFile studentFile = new (filename);

            if (selection == 0)
            {
                Console.Write("CAMPUS         : ");
                string campus = Console.ReadLine();
                FStudent fts = new (id,firstName, lastName, true, campus);
                ListStorage.AddStudent(fts);
                studentFile.AddingToFile(Organizer.Format(fts));
            }
            else
            {
                Console.Write("LECTURER      : ");
                string lecturer = Console.ReadLine();
                DStudent dts = new(id, lecturer, firstName, lastName, true);
                ListStorage.AddStudent(dts);
                studentFile.AddingToFile(Organizer.Format(dts));
            }
            Console.WriteLine($"Student ID: {id} has been added to our system");
            Console.WriteLine("Press any key to go back ...");
            Console.ReadKey();
            AddStudentMenu();
        }
        static void ViewStudents()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(Organizer.StudentReport(ListStorage.GetStudents()));
            Console.WriteLine("\n\n\nPress any Key to go back ...");
            Console.ReadKey();
            MainMenu();
        }
    }
}
