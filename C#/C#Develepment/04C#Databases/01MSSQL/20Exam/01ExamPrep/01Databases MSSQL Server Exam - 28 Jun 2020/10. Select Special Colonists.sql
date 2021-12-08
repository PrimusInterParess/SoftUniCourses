
select subquery.JobDuringJourney,FullName,JobRank
from(
SELECT TC.JobDuringJourney,C.FirstName+ ' '+ C.LastName AS 'FullName',DENSE_RANK() OVER (PARTITION BY JobDuringJourney ORDER BY BirthDate) AS JobRank
	FROM Colonists AS C
		JOIN TravelCards AS TC ON C.Id=TC.ColonistId) as subquery
		where JobRank=2
		