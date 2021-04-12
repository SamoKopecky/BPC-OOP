SELECT s.*, e.ShortName, su.SubjectName 
FROM Students AS s 
	LEFT OUTER JOIN 
	Evaluations AS e
	ON s.Id = e.StudentId 
	LEFT OUTER JOIN
	Subjects AS su
	ON su.ShortName = e.ShortName


SELECT s.SecondName, COUNT(s.SecondName) AS 'Last name counter' 
FROM Students AS s 
	GROUP BY s.SecondName 
	order by 'Last name counter' desc

SELECT e.ShortName, COUNT(e.ShortName) as 'Students count'
FROM Evaluations AS e
	GROUP BY e.ShortName
	HAVING COUNT(e.ShortName) < 3

SELECT e.ShortName, COUNT(e.ShortName) AS 'Number of students',
CAST(AVG(e.EvaluationNumber) AS DECIMAL(10,2)) AS 'Average evaluation',
MAX(e.EvaluationNumber) AS 'Worst evaluation',
MIN(e.EvaluationNumber) AS 'Best evaluation'
FROM Evaluations AS e
	GROUP BY e.ShortName
