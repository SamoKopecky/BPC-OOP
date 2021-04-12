SELECT s.*, e.ShortName, su.SubjectName 
FROM Students AS s 
	LEFT OUTER JOIN 
	Evaluations AS e
	ON s.Id = e.StudentId 
	LEFT OUTER JOIN
	Subjects AS su
	ON su.ShortName = e.ShortName