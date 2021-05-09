﻿using Private_School.PrivateSchoolTableAdapters;
using System;

namespace Private_School
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime SubDateTime { get; private set; }
        public Assignment()
        {
            GetAssignment(Title, Description, SubDateTime);
        }
        private void GetAssignment(string title, string description, DateTime subtDate)
        {
            while (true)
            {
                Console.WriteLine("All Fields Required to be filled\n");
                Console.Write("Title :"); Title = Console.ReadLine(); if (!School.StringValidation(Title)) continue;
                Console.Write("Description :"); Description = Console.ReadLine(); if (!School.StringValidation(Description)) continue;
                Console.Write("Submission Date :"); string dateCheck = Console.ReadLine(); if (!School.DateTimeValidation(dateCheck)) { Console.WriteLine("Wrong Date e.g of correct date(1/1/2001)"); continue; }
                SubDateTime = DateTime.Parse(dateCheck);
                break;
            }
            using (AssignmentsTableAdapter assignmentsTable = new AssignmentsTableAdapter())
            {
                PrivateSchool dbSet = new PrivateSchool();
                assignmentsTable.Insert(Title, Description, SubDateTime);
                assignmentsTable.Fill(dbSet.Assignments);
                assignmentsTable.Update(dbSet);
            }
        }
    }
}