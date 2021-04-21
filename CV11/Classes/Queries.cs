using System;
using System.Collections.Generic;
using System.Linq;

namespace CV11.Classes
{
    public class Queries
    {
        private readonly SchoolDataContext _dbContext;

        public Queries(SchoolDataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void PrintSubjectCounts()
        {
            var list = _dbContext.StudentsCounts.OrderByDescending(c => c.Count);
            foreach (var sc in list)
            {
                Console.WriteLine($"{sc.ShortName}: {sc.Count}");
            }
        }

        public IEnumerable<Student> SubjectsStudents(string subjectShortName)
        {
            //return from e in _dbContext.Evaluations
            //    where e.ShortName == subjectShortName
            //    select e.Student;

            return _dbContext.Evaluations
                .Where(e => e.ShortName == subjectShortName)
                .Select(e => e.Student);
        }

        public IEnumerable<Subject> StudentsSubjects(Guid id)
        {
            //return from e in _dbContext.Evaluations
            //    where e.StudentId == id
            //    select e.Subject;

            return _dbContext.Evaluations
                .Where(e => e.StudentId == id)
                .Select(e => e.Subject);
        }

        public void PrintAverageSubjectEvaluation()
        {
            var query1 = _dbContext.Evaluations.GroupBy(
                e => e.ShortName,
                e => e.EvaluationNumber,
                (name, evaluations) => new
                {
                    Name = name,
                    Average = evaluations.Average(d => d)
                });

            var query2 = _dbContext.Evaluations
                .GroupBy(e => e.ShortName, e => e.EvaluationNumber)
                .Select(g => new
                {
                    Name = g.Key,
                    Average = g.Average(d => d)
                });

            var query3 =
                from e in _dbContext.Evaluations
                group e.EvaluationNumber by e.ShortName
                into g
                select new {Name = g.Key, Average = g.Average(d => d)};

            query1.ToList().ForEach(g => Console.WriteLine($"{g.Name}: {g.Average:F2}"));
        }
    }
}