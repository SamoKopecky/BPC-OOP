DROP TABLE Evaluations
DROP TABLE Students
DROP TABLE Subjects

CREATE TABLE Subjects(
	SubjectName VARCHAR(50),
	ShortName VARCHAR(50) NOT NULL,
	PRIMARY KEY (ShortName)
)

CREATE TABLE Students(
	Id INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50),
	SecondName VARCHAR(50),
	DateOfBirth DATE
	PRIMARY KEY (Id)
)

CREATE TABLE Evaluations(
	StudentId INT,
	ShortName VARCHAR(50),
	EvaluationDate DATE,
	EvaluationNumber FLOAT
	PRIMARY KEY (StudentId, ShortName),
	FOREIGN KEY (StudentId) REFERENCES Students(Id),
	FOREIGN KEY (ShortName) REFERENCES Subjects(ShortName)
)