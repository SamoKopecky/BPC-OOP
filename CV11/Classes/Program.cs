using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Net.Sockets;

namespace CV11.Classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolDataContext();
            SeedDb(context);
            var queries = new Queries(context);
            queries.PrintSubjectCounts();
            PrintSeparator();
            foreach (var student in queries.SubjectsStudents("BPC-OOP"))
            {
                Console.WriteLine($"{student.FirstName} {student.SecondName}");
            }

            PrintSeparator();
            foreach (var subject in queries.StudentsSubjects(Guid.Parse("a427884f-1985-4028-baa3-51d14ce49c56")))
            {
                Console.WriteLine($"{subject.SubjectName} ({subject.ShortName})");
            }

            PrintSeparator();
            queries.PrintAverage();

            Console.ReadKey();
        }


        private static void PrintSeparator()
        {
            Console.WriteLine(new string('-', 30));
        }

        private static void SeedDb(SchoolDataContext context)
        {
            foreach (var student in Seeds.Students)
            {
                var students = context.Students;
                if (students.Any(s => s.Id == student.Id)) continue;
                students.InsertOnSubmit(student);
            }

            foreach (var subject in Seeds.Subjects)
            {
                var subjects = context.Subjects;
                if (subjects.Any(s => s.ShortName == subject.ShortName)) continue;
                subjects.InsertOnSubmit(subject);
            }

            foreach (var evaluation in Seeds.Evaluations)
            {
                var evaluations = context.Evaluations;
                if (evaluations.Any(e =>
                    e.ShortName == evaluation.ShortName ||
                    e.StudentId == evaluation.StudentId)) continue;
                evaluations.InsertOnSubmit(evaluation);
            }

            context.SubmitChanges();
        }
    }
}