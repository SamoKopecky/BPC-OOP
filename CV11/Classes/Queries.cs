﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var query = _dbContext.Evaluations
                .GroupBy(e => e.ShortName)
                .Select(g => new
                {
                    Name = g.Key,
                    Count = g.Count()
                });

            foreach (var g in query.OrderByDescending(arg => arg.Count))
            {
                Console.WriteLine($"{g.Name}: {g.Count}");
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

        public void PrintAverage()
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