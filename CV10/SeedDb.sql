DELETE FROM Evaluations
DELETE FROM Students
DELETE FROM Subjects

INSERT INTO Students(FirstName, SecondName, DateOfBirth) VALUES ('Samuel', 'Kopecký', '05/31/16')
INSERT INTO Students(FirstName, SecondName, DateOfBirth) VALUES ('Adam', 'Kopecký', '05/31/16')
INSERT INTO Students(FirstName, SecondName, DateOfBirth) VALUES ('Jozef', 'Mrkva', '04/29/15')
INSERT INTO Students(FirstName, SecondName, DateOfBirth) VALUES ('Pavol', 'Ostrý', '09/05/18')

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