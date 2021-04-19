using System;
using System.Linq;

namespace CV11.Classes
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new SchoolDataContext();
            SeedDb(context);
            var queries = new Queries(context);

            var query = context.Evaluations
                .GroupBy(e => e.ShortName)
                .Select(g => g);
            var queryOld = from e in context.Evaluations
                group e by e.ShortName;

            queries.PrintSubjectCounts(query);
            PrintSeparator();
            queries.PrintSubjectCounts(queryOld);
            PrintSeparator();
            foreach (var student in queries.SubjectsStudents("BPC-OOP"))
            {
                Console.WriteLine($"{student.FirstName} {student.SecondName}");
            }

            PrintSeparator();
            foreach (var subject in queries.StudentsSubjects(Seeds.Students[0].Id))
            {
                Console.WriteLine($"{subject.SubjectName} ({subject.ShortName})");
            }

            PrintSeparator();
            queries.PrintAverageSubjectEvaluation();

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