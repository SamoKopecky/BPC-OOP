CREATE VIEW StudentsCount AS SELECT e.ShortName, COUNT(e.ShortName) as Count FROM Evaluations AS e GROUP BY e.ShortName