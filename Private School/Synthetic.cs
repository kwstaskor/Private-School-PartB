using Private_School.PrivateSchoolTableAdapters;
using System;

namespace Private_School
{
    public class Synthetic
    {
        public static void CreateSyntheticData()
        {
            using (var dbSet = new PrivateSchool())
            {
                FillCoursesTable(dbSet);

                FillTrainersTable(dbSet);

                FillStudentsTable(dbSet);

                FillAssignmentsTable(dbSet);
            }
        }
        private static void FillCoursesTable(PrivateSchool dbSet)
        {
            var coursesTable = new CoursesTableAdapter();
            coursesTable.Insert("Programing Fundamentals", "Java", "Part Time", new DateTime(2021, 2, 15), new DateTime(2021, 9, 15));
            coursesTable.Insert("Programing Advanced", "C#", "Full Time", new DateTime(2021, 2, 15), new DateTime(2021, 5, 15));
            coursesTable.Insert("Programing Fundamentals", "C#", "Part Time", new DateTime(2021, 2, 15), new DateTime(2021, 9, 15));
            coursesTable.Insert("Programing Advanced", "Java", "Full Time", new DateTime(2021, 2, 15), new DateTime(2021, 5, 15));
            coursesTable.Fill(dbSet.Courses);
        }
        private static void FillTrainersTable(PrivateSchool dbSet)
        {
            var trainersTable = new TrainersTableAdapter();
            trainersTable.Insert("Giorgos", "Evagelou", "Computer Science");
            trainersTable.Insert("Vagelis", "Dimitrou", "Computer Science");
            trainersTable.Insert("Dimitris", "Kostantinou", "Computer Science");
            trainersTable.Insert("Andreas", "Andreou", "Computer Science");
            trainersTable.Fill(dbSet.Trainers);
        }
        private static void FillStudentsTable(PrivateSchool dbSet)
        {
            var studentsTable = new StudentsTableAdapter();
            studentsTable.Insert("Kostas", "Papaxristou", new DateTime(1991, 5, 5));
            studentsTable.Insert("Xristos", "Papakostas", new DateTime(1991, 4, 5));
            studentsTable.Insert("Giorgos", "Ioanou", new DateTime(1991, 6, 5));
            studentsTable.Insert("Giannis", "Georgiou", new DateTime(1991, 3, 3));
            studentsTable.Insert("Giannis", "Georgiou", new DateTime(1991, 3, 3));
            studentsTable.Insert("Xristina", "Papakosta", new DateTime(1991, 2, 3));
            studentsTable.Fill(dbSet.Students);
        }
        private static void FillAssignmentsTable(PrivateSchool dbSet)
        {
            var assignmentsTable = new AssignmentsTableAdapter();
            assignmentsTable.Insert("Private School", "Individual Project", new DateTime(2021, 3, 31));
            assignmentsTable.Insert("Data Bases", "Individual Project", new DateTime(2021, 3, 31));
            assignmentsTable.Insert("Web Security", "Group Project", new DateTime(2021, 3, 15));
            assignmentsTable.Insert("Web Application", "Group Project", new DateTime(2021, 3, 15));
            assignmentsTable.Fill(dbSet.Assignments);
        }
    }
}
