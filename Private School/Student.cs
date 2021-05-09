using Private_School.PrivateSchoolTableAdapters;
using System;

namespace Private_School
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public Student()
        {
            GetStudent(FirstName, LastName, DateOfBirth);
        }
        private void GetStudent(string firstName, string lastName, DateTime date)
        {
            while (true)
            {
                Console.WriteLine("All Fields Required to be filled\n");
                Console.Write("First Name :"); FirstName = Console.ReadLine(); if (!School.StringValidation(FirstName)) continue;
                Console.Write("Last Name :"); LastName = Console.ReadLine(); if (!School.StringValidation(LastName)) continue;
                Console.Write("Date of birth :"); string dateCheck = Console.ReadLine(); if (!School.DateTimeValidation(dateCheck)) { Console.WriteLine("Wrong Date e.g of correct date(1/1/2001)"); continue; }
                DateOfBirth = DateTime.Parse(dateCheck);
                break;
            }
            using (StudentsTableAdapter studentsTable = new StudentsTableAdapter())
            {
                PrivateSchool dbSet = new PrivateSchool();
                studentsTable.Insert(FirstName, LastName, DateOfBirth);
                studentsTable.Fill(dbSet.Students);
            }
        }
    }
}
