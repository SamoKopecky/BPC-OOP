SELECT e.ShortName, COUNT(e.ShortName)
FROM Evaluations AS e
	GROUP BY e.ShortName
	HAVING COUNT(e.ShortName) < 3