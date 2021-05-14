using Private_School.PrivateSchoolTableAdapters;
using System;

namespace Private_School
{
    public class Trainer
    {
        public int Id { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Subject { get; private set; }
        public Trainer()
        {
            GetTrainer(FirstName, LastName, Subject);
        }
        private void GetTrainer(string firstName, string lastName, string subject)
        {
            while (true)
            {
                Console.WriteLine("All Fields Required to be filled\n");
                Console.Write("First Name :"); FirstName = Console.ReadLine(); if (!School.StringValidation(FirstName)) continue;
                Console.Write("Last Name :"); LastName = Console.ReadLine(); if (!School.StringValidation(LastName)) continue;
                Console.Write("Subject :"); Subject = Console.ReadLine(); if (!School.StringValidation(Subject)) continue;
                break;
            }
            AddTrainerToDb();
        }

        private void AddTrainerToDb()
        {
            using (TrainersTableAdapter trainersTable = new TrainersTableAdapter())
            {
                PrivateSchool dbSet = new PrivateSchool();
                trainersTable.Insert(FirstName, LastName, Subject);
                trainersTable.Fill(dbSet.Trainers);
            }
        }
    }
}
