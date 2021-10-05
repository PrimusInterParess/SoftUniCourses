use TripService
select c.Name,count(h.CityId)
from Cities as c
 join Hotels as h on h.CityId=c.Id
	group by c.Name
	order by count(h.CityId) desc,c.Name

