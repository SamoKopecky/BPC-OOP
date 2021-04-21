DELETE FROM Evaluations
DELETE FROM Students
DELETE FROM Subjects

INSERT INTO Students(Id, FirstName, SecondName, DateOfBirth) VALUES ('3dd17784-48a5-4ec4-ae59-f94f4459de72', 'Samuel', 'Kopecký', '05/31/16')
INSERT INTO Students(Id, FirstName, SecondName, DateOfBirth) VALUES ('cc0c000b-4d61-4735-9e57-8eb6387516ae', 'Adam', 'Kopecký', '05/31/16')
INSERT INTO Students(Id, FirstName, SecondName, DateOfBirth) VALUES ('d384b638-7891-4e72-ab62-5de81c3e3385', 'Jozef', 'Mrkva', '04/29/15')
INSERT INTO Students(Id, FirstName, SecondName, DateOfBirth) VALUES ('8df5c686-560d-4584-a530-f441099a5b19', 'Pavol', 'Ostrý', '09/05/18')

INSERT INTO Subjects(SubjectName, ShortName) VALUES ('Bezpečnost ICT 2', 'BPC-IC2')
INSERT INTO Subjects(SubjectName, ShortName) VALUES ('Objektově orientované programování', 'BPC-OOP')
INSERT INTO Subjects(SubjectName, ShortName) VALUES ('Teorie kryptografických protokolů', 'BPC-CPT')

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Samuel'),
	('BPC-IC2'),
	('04/12/21'),
	('1')
)

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Samuel'),
	('BPC-OOP'),
	('04/13/21'),
	('3')
)

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Samuel'),
	('BPC-CPT'),
	('04/14/21'),
	('5')
)

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Adam'),
	('BPC-CPT'),
	('04/14/21'),
	('2')
)

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Jozef'),
	('BPC-CPT'),
	('04/14/21'),
	('3')
)

INSERT INTO Evaluations(StudentId, ShortName, EvaluationDate, EvaluationNumber) VALUES (
	(SELECT id FROM Students WHERE FirstName='Pavol'),
	('BPC-OOP'),
	('04/13/21'),
	('4')
)