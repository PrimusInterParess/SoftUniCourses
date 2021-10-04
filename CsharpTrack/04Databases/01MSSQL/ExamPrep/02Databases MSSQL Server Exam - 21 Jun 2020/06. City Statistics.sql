select c.Name,count(h.Id)
from Cities as c
right join Hotels as h on h.CityId=c.Id
	group by c.Name
	order by count(h.Id) desc,c.Name

SELECT c.Name, COUNT(h.CityId)
	FROM Cities AS c
	JOIN Hotels AS h ON h.CityId = c.Id
 GROUP BY c.Name
 ORDER BY COUNT(h.CityId) DESC,c.Name