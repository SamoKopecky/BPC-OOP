SELECT e.ShortName, COUNT(e.ShortName) AS 'Number of students',
CAST(AVG(e.EvaluationNumber) AS DECIMAL(10,2)) AS 'Average evaluation',
MAX(e.EvaluationNumber) AS 'Worst evaluation',
MIN(e.EvaluationNumber) AS 'Best evaluation'
FROM Evaluations AS e
	GROUP BY e.ShortName
