using System;
using System.Collections.Generic;

namespace CV11.Classes
{
    public class Seeds
    {
        public static readonly List<Student> Students = new List<Student>()
        {
            new Student()
            {
                Id = Guid.Parse("a427884f-1985-4028-baa3-51d14ce49c56"),
                FirstName = "Samuel",
                SecondName = "Kopecky",
                DateOfBirth = new DateTime(16, 5, 31)
            },
            new Student()
            {
                Id = Guid.Parse("39fe9be0-51ec-4a8d-a305-ec57e749abdb"),
                FirstName = "Adam",
                SecondName = "Kopecky",
                DateOfBirth = new DateTime(17, 5, 31)
            },
            new Student()
            {
                Id = Guid.Parse("5fd05ca5-fe7b-4f8d-b5c0-ee0d1fef5e8a"),
                FirstName = "Jozef",
                SecondName = "Mrkva",
                DateOfBirth = new DateTime(15, 4, 29)
            },
            new Student()
            {
                Id = Guid.Parse("ba3383c1-47ff-46df-bf4e-1018a1ff7fd1"),
                FirstName = "Pavol",
                SecondName = "Ostrý",
                DateOfBirth = new DateTime(18, 9, 5)
            },
        };

        public static readonly List<Subject> Subjects = new List<Subject>()
        {
            new Subject()
            {
                ShortName = "BPC-IC2",
                SubjectName = "Bezpečnost ICT 2"
            },
            new Subject()
            {
                ShortName = "BPC-OOP",
                SubjectName = "Objektově orientované programování"
            },
            new Subject()
            {
                ShortName = "BPC-CPT",
                SubjectName = "Teorie kryptografických protokolů"
            },
        };

        public static readonly List<Evaluation> Evaluations = new List<Evaluation>()
        {
            new Evaluation()
            {
                StudentId = Students[0].Id,
                ShortName = "BPC-IC2",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 1D
            },
            new Evaluation()
            {
                StudentId = Students[0].Id,
                ShortName = "BPC-OOP",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 3D
            },
            new Evaluation()
            {
                StudentId = Students[0].Id,
                ShortName = "BPC-CPT",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 5D
            },
            new Evaluation()
            {
                StudentId = Students[1].Id,
                ShortName = "BPC-CPT",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 2D
            },
            new Evaluation()
            {
                StudentId = Students[2].Id,
                ShortName = "BPC-CPT",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 3D
            },
            new Evaluation()
            {
                StudentId = Students[3].Id,
                ShortName = "BPC-OOP",
                EvaluationDate = new DateTime(21, 4, 12),
                EvaluationNumber = 4D
            }
        };
    }
}