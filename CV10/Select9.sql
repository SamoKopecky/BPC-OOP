SELECT s.SecondName, COUNT(s.SecondName) AS 'LASt name COUNT' 
FROM Students AS s 
	GROUP BY s.SecondName 
	order by 'LASt name COUNT' desc