using Private_School;
using System;

public static class Menu
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t\t\tWelcome to PRIVATE SCHOOL Console app\n\n\n" +
                "1)Add Synthetic Data \n2)Continue to Main menu \n3)Exit\n\n");
            Console.ResetColor();

            switch (Console.ReadLine())
            {
                case "1":
                    Synthetic.CreateSyntheticData();
                    MainMenu();
                    continue;
                case "2":
                    MainMenu();
                    continue;
                case "3":
                    break;
            }
            break;
        }
    }
    public static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\t\t\t---------------Private School---------------\n\nHello Welcome to Private school");
            Console.WriteLine("\n\tMain Menu \n1) Register \n2) View all \n3) Delete Menu \n4) Exit\n\n");
            Console.Write("Select an option. : ");

            switch (Console.ReadLine())
            {
                case "1":
                    RegisterMenu();
                    continue;
                case "2":
                    PrintMenu();
                    continue;
                case "3":
                     DeleteMenu();
                    continue;
                case "4":
                    break;
                default:
                    continue;
            }
            break;
        }
    }
    public static void RegisterMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\tRegister Menu \n1) Add Courses \n2) Add Assignments \n3) Add Trainers \n4) Add Students \n5) Assign Trainers to Courses \n6) Assign Students to Courses \n7) Assign Assignments to Courses" +
                "\n8) Assign Assignments to Students \n\n");
            Console.Write("Select an option , or press Enter to return to Main Menu  : ");

            switch (Console.ReadLine())
            {
                case "1":
                    School.RegisterCourse();
                    continue;
                case "2":
                    School.RegisterAssignment();
                    continue;
                case "3":
                    School.RegisterTrainer();
                    continue;
                case "4":
                    School.RegisterStudent();
                    continue;
                case "5":
                    School.TrainersPerCourseMatch();
                    continue;
                case "6":
                    School.StudentsPerCourseMatch();
                    continue;
                case "7":
                    School.AssignmentsPerCourseMatch();
                    continue;
                case "8":
                    School.AssignmentsPerStudentMatch();
                    continue;
                default:
                    break;
            }
            break;
        }
    }
    public static void PrintMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\tView Menu \n1) All Courses \n2) All Assignments \n3) All Trainers \n4) All Students \n5) Trainers Per Course \n6) Assignments Per Course \n7) Students per Course" +
                "\n8) Assignments per Student \n9) Students with two courses or more \n\n");
            Console.Write("Select an option , or press Enter to return to Main Menu : ");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    School.PrintAllCourses();
                    Console.Write("\n\nPress Enter to return to View menu.");
                    Console.ReadLine();
                    continue;
                case "2":
                    Console.Clear();
                    School.PrintAllAssignments();
                    Console.Write("\n\nPress Enter to return to View menu.");
                    Console.ReadLine();
                    continue;
                case "3":
                    Console.Clear();
                    School.PrintAllTrainers();
                    Console.Write("\n\nPress Enter to return to View menu.");
                    Console.ReadLine();
                    continue;
                case "4":
                    Console.Clear();
                    School.PrintAllStudents();
                    Console.Write("\n\nPress Enter to return to View menu.");
                    Console.ReadLine();
                    continue;
                case "5":
                    Console.Clear();
                    School.PrintAllTrainersPerCourse();
                    Console.Write("\n\nPress Enter to return to View Menu.");
                    Console.ReadLine();
                    continue;
                case "6":
                    Console.Clear();
                    School.PrintAllAssignmentsPerCourse();
                    Console.Write("\n\nPress Enter to return to View Menu.");
                    Console.ReadLine();
                    continue;
                case "7":
                    Console.Clear();
                    School.PrintAllStudentsPerCourse();
                    Console.Write("\n\nPress Enter to return to View Menu.");
                    Console.ReadLine();
                    continue;
                case "8":
                    Console.Clear();
                    School.PrintAllAssignmentsPerStudent();
                    Console.Write("\n\nPress Enter to return to View Menu.");
                    Console.ReadLine();
                    continue;
                case "9":
                    Console.Clear();
                    School.PrintAllStudentsWithMoreThanOneCourses();
                    Console.Write("\n\nPress Enter to return to View Menu.");
                    Console.ReadLine();
                    continue;
                default:
                    break;
            }
            break;
        }
    }
    public static void DeleteMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("\tDelete Menu \n1) Delete Courses \n2) Delete Assignments \n3) Delete Trainers \n4) Delete Students \n\n");
            Console.Write("Select an option , or press Enter to return to Main Menu  : ");

            switch (Console.ReadLine())
            {
                case "1":
                    School.DeleteCourse();
                    continue;
                case "2":
                    School.DeleteAssignment();
                    continue;
                case "3":
                    School.DeleteTrainer();
                    continue;
                case "4":
                    School.DeleteStudent();
                    continue;
                default:
                    break;
            }
            break;
        }
    }
}
