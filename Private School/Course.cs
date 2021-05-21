using Private_School.PrivateSchoolTableAdapters;
using System;

namespace Private_School
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Stream { get; private set; }
        public string Type { get; private set; }
        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        
        public Course()
        {
            GetCourse(Title, Stream, Type, StartDate, EndDate);
          
        }
        public void GetCourse(string title, string description, string type, DateTime startDate, DateTime endDate)
        {
            while (true)
            {
                Console.WriteLine("All Fields Required to be filled\n");
                Console.Write("Title :"); Title = Console.ReadLine(); if (!School.StringValidation(Title)) continue;
                Console.Write("Stream :"); Stream = Console.ReadLine(); if (!School.StringValidation(Stream)) continue;
                Console.Write("Type :"); Type = Console.ReadLine(); if (!School.StringValidation(Type)) continue;
                Console.Write("Start Date :"); var startCheck = Console.ReadLine(); if (!School.DateTimeValidation(startCheck)) { Console.WriteLine("Wrong Date e.g of correct date(1/1/2001)"); continue; }
                Console.Write("End Date :"); var endCheck = Console.ReadLine(); if (!School.DateTimeValidation(endCheck)) { Console.WriteLine("Wrong Date e.g of correct date(1/1/2001)"); continue; }
                StartDate = DateTime.Parse(startCheck);
                EndDate = DateTime.Parse(endCheck);
                break;
            }
            AddCourseToDb();
        }

        private void AddCourseToDb()
        {
            using (var coursesTable = new CoursesTableAdapter())
            {
                var dbSet = new PrivateSchool();
                coursesTable.Insert(Title, Stream, Type, StartDate, EndDate);
                coursesTable.Fill(dbSet.Courses);
            }
        }
    }
}
