using Private_School.PrivateSchoolTableAdapters;
using System;
using System.Linq;
using static Private_School.PrivateSchool;

namespace Private_School
{
    class School
    {
        #region Console Messages
        private static void ConsoleMessageForCourse()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t----Choose Course/Courses----\n\n\tType Course Number to Assign and PRESS Enter or PRESS Enter without typing a number to exit\n");
            PrintAllCourses();
            Console.Write("\n\nCourse Number or press enter to exit... :");
        }
        private static void ConsoleMessageForAssignment()
        {
            Console.Clear();
            PrintAllAssignments();
            Console.WriteLine("\n\t\t\t\t----Choose Assignment----\n\n\t\tType Assignments Number to Assign and PRESS Enter\n");
            Console.Write("Assignment Number :");
        }
        private static void ConsoleMessageForStudents()
        {
            Console.Clear();
            PrintAllStudents();
            Console.WriteLine("\n\t\t\t\t----Choose Student----\n\n\t\tType Students Number to Assign and PRESS Enter\n");
            Console.Write("Student Number :");
        }
        private static void ConsoleMessageForTrainers()
        {
            Console.Clear();
            PrintAllTrainers();
            Console.WriteLine("\n\t\t\t\t----Choose Trainer----\n\n\t\tType Trainers Number to Assign and PRESS Enter\n");
        }
        private static void ConsoleMessageForStudentsCourses()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t----Choose Student/Students----\n\n\tType Course and Student Number to Assign or PRESS Enter without typing a number to exit\n");
            PrintAllStudentsPerCourse();
        }
        #endregion

        #region Input Validation
        public static bool StringValidation(string input) => !string.IsNullOrWhiteSpace(input);
      
        public static bool DateTimeValidation(string input)
        {
            try
            {
                Convert.ToDateTime(input);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Assignment Logic
        public static void RegisterAssignment() 
        {
            int counter = 0;
            while (counter != 2)
            {
                Console.Clear();
                var assignment = new Assignment();
                Console.WriteLine("\n1) Add another Assignment \n2) Return to Register Menu");
                counter = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void PrintAllAssignments()
        {
            using (AssignmentsTableAdapter assignmentsTable = new AssignmentsTableAdapter())
            {
                var assignments = assignmentsTable.GetData().ToList();
                foreach (var assignment in assignments)
                {
                    Console.WriteLine($"ID:{assignment.ID,-5} Title:{assignment.title.ToUpper(),-15} Description:{assignment.description.ToUpper(),-20} Submission:{assignment.subDateTime:dd/MM/yyyy}");
                }
            }
        }
        public static void DeleteAssignment()
        {
            var choise = Console.ReadLine();
            using (AssignmentsTableAdapter assignmentsTable = new AssignmentsTableAdapter())
            {
                if (StringValidation(choise))
                {
                    try
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        assignmentsTable.Fill(dbSet.Assignments);
                        dbSet.Assignments.FindByID(Convert.ToInt32(choise)).Delete();
                        assignmentsTable.Update(dbSet.Assignments);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong ID please try again....");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion

        #region Courses Logic
        public static void RegisterCourse()
        {
            int choise = 0;
            while (choise != 2)
            {
                Console.Clear();
                var course = new Course();
                Console.WriteLine("\n1) Add another course \n2) Return to Register Menu");
                choise = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void PrintAllCourses()
        {
            using (CoursesTableAdapter coursesTable = new CoursesTableAdapter())
            {
                var courses = coursesTable.GetData().ToList();
                foreach (var course in courses)
                {
                    Console.WriteLine($"ID:{course.ID,-5} Title:{course.title.ToUpper(),-25} Stream:{course.stream.ToUpper(),-10} Type:{course.type.ToUpper(),-15} " +
                        $"Start Date:{course.startDate,-15:dd/MM/yyyy} End Date:{course.endDate,-15:dd/MM/yyyy}");
                }
            }
        }

        public static void DeleteCourse()
        {
            var choise = Console.ReadLine();
            using (CoursesTableAdapter coursesTable = new CoursesTableAdapter())
            {
                if (StringValidation(choise))
                {
                    try
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        coursesTable.Fill(dbSet.Courses);
                        dbSet.Courses.FindByID(Convert.ToInt32(choise)).Delete();
                        coursesTable.Update(dbSet.Courses);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong ID please try again....");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion

        #region Trainers Logic
        public static void RegisterTrainer()
        {
            int counter = 0;
            while (counter != 2)
            {
                Console.Clear();
                var trainer = new Trainer();
                Console.WriteLine("\n1) Add another trainer \n2) Return to Register Menu");
                counter = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void PrintAllTrainers()
        {
            using (TrainersTableAdapter trainersTable = new TrainersTableAdapter())
            {
                var trainers = trainersTable.GetData().ToList();
                foreach (var trainer in trainers)
                {
                    Console.WriteLine($"ID:{trainer.ID,-5} Firstname:{trainer.firstName.ToUpper(),-15} Lastname:{trainer.lastName.ToUpper(),-15} ");
                }
            }
        }
        public static void DeleteTrainer()
        {
            var choise = Console.ReadLine();
            using (TrainersTableAdapter trainersTable = new TrainersTableAdapter())
            {
                if (StringValidation(choise))
                {
                    try
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        trainersTable.Fill(dbSet.Trainers);
                        dbSet.Trainers.FindByID(Convert.ToInt32(choise)).Delete();
                        trainersTable.Update(dbSet.Trainers);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong ID please try again....");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion

        #region Students Logic
        public static void RegisterStudent()
        {
            int counter = 0;
            while (counter != 2)
            {
                Console.Clear();
                var student = new Student();
                Console.WriteLine("\n1) Add another Student \n2) Return to Register Menu");
                counter = Convert.ToInt32(Console.ReadLine());
            }
        }
        public static void PrintAllStudents()
        {
            using (StudentsTableAdapter studentsTable = new StudentsTableAdapter())
            {
                var students = studentsTable.GetData().ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID:{student.ID,-5} Firstname:{student.firstName.ToUpper(),-15} Lastname {student.lastName.ToUpper(),-15} Date of Birth:{student.dateOfBirth,-15:dd/MM/yyyy} ");
                }
            }
        }
        public static void DeleteStudent()
        {
            var choise = Console.ReadLine();
            using (StudentsTableAdapter studentsTable = new StudentsTableAdapter())
            {
                if (StringValidation(choise))
                {
                    try
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        studentsTable.Fill(dbSet.Students);
                        dbSet.Students.FindByID(Convert.ToInt32(choise)).Delete();
                        studentsTable.Update(dbSet.Students);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Wrong ID please try again....");
                        Console.ReadKey();
                    }
                }
            }
        }
        #endregion

        #region TrainersPerCourse
        public static void TrainersPerCourseMatch()
        {
            ConsoleMessageForTrainers();
            var choise = Console.ReadLine();
            PrivateSchool dbSet = new PrivateSchool();
            if (StringValidation(choise))
            {
                TrainersCoursesRow trainersCoursesRow = dbSet.TrainersCourses.NewTrainersCoursesRow();
                trainersCoursesRow.TrainerID = Convert.ToInt32(choise);
                TrainersCourseSelection(trainersCoursesRow);
            }
        }
        private static void TrainersCourseSelection(TrainersCoursesRow trainersCoursesRow)
        {
            ConsoleMessageForCourse();
            do
            {
                var choise = Console.ReadLine();
                if (StringValidation(choise))
                {
                    using (TrainersCoursesTableAdapter trainersCoursesTable = new TrainersCoursesTableAdapter())
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        trainersCoursesRow.CourseID = Convert.ToInt32(choise);
                        try
                        {
                            AddToTrainersCoursesTable(trainersCoursesRow, trainersCoursesTable, dbSet);
                            Console.WriteLine("Another Course number? :");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("This Course already belongs to this Trainer.\nTry again....");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else
                    break;
            }
            while (true);
        }

        private static void AddToTrainersCoursesTable(TrainersCoursesRow trainersCoursesRow, TrainersCoursesTableAdapter trainersCoursesTable,
                                                      PrivateSchool dbSet)
        {
            trainersCoursesTable.Insert(trainersCoursesRow.TrainerID, trainersCoursesRow.CourseID);
            trainersCoursesTable.Update(dbSet.TrainersCourses);
        }
        public static void PrintAllTrainersPerCourse()
        {
            Console.Clear();
            using (TrainersPerCoursesTableAdapter trainersPerCoursesTableAdapter = new TrainersPerCoursesTableAdapter())
            {
                var trainersPerCoursesRows = trainersPerCoursesTableAdapter.GetData();
                if (trainersPerCoursesRows.Count > 0)
                {
                    foreach (var trainerCourse in trainersPerCoursesRows)
                    {
                        Console.WriteLine($"Trainer:{trainerCourse.firstName,-11} {trainerCourse.lastName,-15} Course:{trainerCourse.stream,-10} " +
                            $"{trainerCourse.Course_Type}");
                    }
                }
                else
                    Console.WriteLine("There is no trainer or course matched...\nGo to Register Menu to match trainers with courses...");
            }
        }
        #endregion

        #region StudentsPerCourse
        public static void StudentsPerCourseMatch()
        {
            ConsoleMessageForStudents();
            var choise = Console.ReadLine();
            if (StringValidation(choise))
            {
                PrivateSchool dbSet = new PrivateSchool();
                StudentsCoursesRow studentsCoursesRow = dbSet.StudentsCourses.NewStudentsCoursesRow();
                studentsCoursesRow.StudentID = Convert.ToInt32(choise);
                StudentsCourseSelection(studentsCoursesRow);
            }
        }
        private static void StudentsCourseSelection(StudentsCoursesRow studentsCoursesRow)
        {
            ConsoleMessageForCourse();
            do
            {
                var choise = Console.ReadLine();
                Console.Write("What is the Tuition Fee for this Course? :");
                var tuituionFee = Console.ReadLine();
                if (StringValidation(choise) && StringValidation(tuituionFee))
                {
                    using (StudentsCoursesTableAdapter studentsCoursesTable = new StudentsCoursesTableAdapter())
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        try
                        {
                            AddToStudentsCourseTable(studentsCoursesRow, choise, tuituionFee, studentsCoursesTable, dbSet);
                            Console.Write("Another Course number? :");
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("This Course already belongs to this Student.\nTry again....");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else
                    Console.WriteLine("All Fields required to be filled.Try again...");
                Console.ReadKey();
                break;
            }
            while (true);
        }

        private static void AddToStudentsCourseTable(StudentsCoursesRow studentsCoursesRow, string choise, string tuituionFee,
                                                     StudentsCoursesTableAdapter studentsCoursesTable, PrivateSchool dbSet)
        {
            studentsCoursesRow.CourseID = Convert.ToInt32(choise);
            studentsCoursesRow.tuitionFees = Convert.ToSingle(tuituionFee);
            studentsCoursesTable.Insert(studentsCoursesRow.CourseID, studentsCoursesRow.StudentID, studentsCoursesRow.tuitionFees);
            studentsCoursesTable.Update(dbSet.StudentsCourses);
        }
        public static void PrintAllStudentsPerCourse()
        {
            using (StudentsPerCoursesTableAdapter studentsPerCoursesTable = new StudentsPerCoursesTableAdapter())
            {
                var studentsCoursesRows = studentsPerCoursesTable.GetData().ToList();
                if (studentsCoursesRows.Count > 0)
                {
                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                    foreach (var studentsCourse in studentsCoursesRows)
                    {
                        Console.WriteLine($"Course ID:{studentsCourse.Courses_Id,-5} Stream:{studentsCourse.stream,-10} Type:{studentsCourse.Course_Type,-20} " +
                            $"Student ID:{studentsCourse.Students_Id,-5} Student Name:{studentsCourse.firstName,-12} {studentsCourse.lastName,-15} Fee:{studentsCourse.tuitionFees} €");
                    }
                }
                else
                    Console.WriteLine("There is no student or course matched...\nGo to Register Menu to match students with courses...");
            }
        }
        public static void PrintAllStudentsWithMoreThanOneCourses()
        {
            using (StudentsWithMoreThanOneCourseTableAdapter studentsWithMoreThanOneCourse = new StudentsWithMoreThanOneCourseTableAdapter())
            {
                var studentsCoursesRows = studentsWithMoreThanOneCourse.GetData().ToList();
                if (studentsCoursesRows.Count > 0)
                {
                    foreach (var students in studentsCoursesRows)
                    {
                        Console.WriteLine($"Name: {students.firstName,-12} {students.lastName,-15} Number of Courses: {students.Number_Of_Courses,-15}");
                    }
                }
                else
                    Console.WriteLine("There is no student with more than one courses...\nGo to Register Menu to match students with courses...");

            }
        }
        #endregion

        #region AssignmentPerCourse
        public static void AssignmentsPerCourseMatch()
        {
            ConsoleMessageForAssignment();
            var choise = Console.ReadLine();
            if (StringValidation(choise))
            {
                PrivateSchool dbSet = new PrivateSchool();
                AssignmentsCoursesRow assignmentsCoursesRow = dbSet.AssignmentsCourses.NewAssignmentsCoursesRow();
                assignmentsCoursesRow.AssignmentID = Convert.ToInt32(choise);
                AssignmentsCourseSelection(assignmentsCoursesRow);
            }
        }
        private static void AssignmentsCourseSelection(AssignmentsCoursesRow assignmentsCoursesRow)
        {
            ConsoleMessageForCourse();
            do
            {
                var choise = Console.ReadLine();
                if (StringValidation(choise))
                {
                    string oralMark, totalMark;
                    NewMethod(out oralMark, out totalMark);
                    if (StringValidation(oralMark) && StringValidation(totalMark))
                    {
                        using (AssignmentsCoursesTableAdapter assignmentsCoursesTable = new AssignmentsCoursesTableAdapter())
                        {
                            PrivateSchool dbSet = new PrivateSchool();
                            try
                            {
                                AddToAssignmentsCoursesTable(assignmentsCoursesRow, choise, oralMark, totalMark, assignmentsCoursesTable, dbSet);
                                Console.Write("Another Course number? :");
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("This Course already belongs to this Assignment.\nTry again....");
                                Console.ReadKey();
                                break;
                            }
                        }
                    }
                    else
                        Console.WriteLine("All fields required to be filled.Try again....");
                }
                else
                    break;
            }
            while (true);
        }

        private static void NewMethod(out string oralMark, out string totalMark)
        {
            Console.Write("What is the Oral Mark for this Course? :");
            oralMark = Console.ReadLine();
            Console.Write("What is the Total Mark for this Course? :");
            totalMark = Console.ReadLine();
        }

        private static void AddToAssignmentsCoursesTable(AssignmentsCoursesRow assignmentsCoursesRow, string choise, string oralMark,
                                                         string totalMark, AssignmentsCoursesTableAdapter assignmentsCoursesTable, PrivateSchool dbSet)
        {
            assignmentsCoursesRow.CourseID = Convert.ToInt32(choise);
            assignmentsCoursesRow.oralMark = Convert.ToSingle(oralMark);
            assignmentsCoursesRow.totalMark = Convert.ToSingle(totalMark);
            assignmentsCoursesTable.Insert(assignmentsCoursesRow.AssignmentID, assignmentsCoursesRow.CourseID, assignmentsCoursesRow.oralMark, assignmentsCoursesRow.totalMark);
            assignmentsCoursesTable.Update(dbSet.AssignmentsCourses);

        }
        public static void PrintAllAssignmentsPerCourse()
        {
            using (AssignmentsPerCoursesTableAdapter assignmentsPerCoursesTable = new AssignmentsPerCoursesTableAdapter())
            {
                var assignmentsCoursesRows = assignmentsPerCoursesTable.GetData().ToList();
                if (assignmentsCoursesRows.Count > 0)
                {
                    foreach (var assignmentsCourse in assignmentsCoursesRows)
                    {
                        Console.WriteLine($"Course:{assignmentsCourse.Course_Type,-15} {assignmentsCourse.stream,-10} " +
                            $"Assignment:{assignmentsCourse.Assignment_Title,-10} {assignmentsCourse.description,-25} Oral Mark:{assignmentsCourse.oralMark,-5} Total Mark:{assignmentsCourse.totalMark,-5}");
                    }
                }
                else
                    Console.WriteLine("There is no assignment or course matched...\nGo to Register Menu to match assignments with courses...");
            }
        }
        #endregion

        #region AssignmentPerStudent
        public static void AssignmentsPerStudentMatch()
        {
            ConsoleMessageForAssignment();
            var choise = Console.ReadLine();
            PrivateSchool dbSet = new PrivateSchool();
            if (StringValidation(choise))
            {
                StudentsAssignmentsRow studentsAssignmentsRow = dbSet.StudentsAssignments.NewStudentsAssignmentsRow();
                studentsAssignmentsRow.AssignmentID = Convert.ToInt32(choise);
                AssignmentsStudentSelection(studentsAssignmentsRow);
            }
        }
        private static void AssignmentsStudentSelection(StudentsAssignmentsRow studentsAssignmentsRow)
        {
            ConsoleMessageForStudentsCourses();
            do
            {
                Console.Write("\n\nCourse Number? :");
                var choise = Console.ReadLine();
                Console.Write("\n\nStudent Number? :");
                var secondChoice = Console.ReadLine();
                if (StringValidation(choise) && StringValidation(secondChoice))
                {
                    using (StudentsAssignmentsTableAdapter studentsAssignmentsTable = new StudentsAssignmentsTableAdapter())
                    {
                        PrivateSchool dbSet = new PrivateSchool();
                        try
                        {
                            AddToAssignmentsStudentsTable(studentsAssignmentsRow, choise, secondChoice, studentsAssignmentsTable, dbSet);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("This Student already belongs to this Assignment.\nTry again....");
                            Console.ReadKey();
                            break;
                        }
                    }
                }
                else
                    break;
            }
            while (true);
        }
        private static void AddToAssignmentsStudentsTable(StudentsAssignmentsRow studentsAssignmentsRow, string choise, string secondChoice,
                                                          StudentsAssignmentsTableAdapter studentsAssignmentsTable, PrivateSchool dbSet)
        {
            studentsAssignmentsRow.CoursesID = Convert.ToInt32(choise);
            studentsAssignmentsRow.StudentsID = Convert.ToInt32(secondChoice);
            studentsAssignmentsTable.Insert(studentsAssignmentsRow.AssignmentID, studentsAssignmentsRow.StudentsID, studentsAssignmentsRow.CoursesID);
            studentsAssignmentsTable.Update(dbSet.StudentsAssignments);
        }
        public static void PrintAllAssignmentsPerStudent()
        {
            using (AssignmentPerCoursePerStudentTableAdapter studentsAssignments = new AssignmentPerCoursePerStudentTableAdapter())
            {
                var studentsAssignmentsRows = studentsAssignments.GetData().ToList();
                if (studentsAssignmentsRows.Count > 0)
                {
                    foreach (var studentsAssignmentsRow in studentsAssignmentsRows)
                    {
                        Console.WriteLine($"Assignment Title:{studentsAssignmentsRow.Assignments_Title,-15} Description:{studentsAssignmentsRow.description,-25} " +
                            $"Submission:{studentsAssignmentsRow.subDateTime,-25:dd/MM/yyyy} " +
                            $"Student:{studentsAssignmentsRow.FirstName,-15} {studentsAssignmentsRow.LastName,-15} " +
                            $"Course:{studentsAssignmentsRow.Course_Title,-15} {studentsAssignmentsRow.Course_Type,-15} ");
                    }
                }
                else
                    Console.WriteLine("There is no assignment or student matched...\nGo to Register Menu to match students with assignments...");
            }
        }
        #endregion 
    }
}
