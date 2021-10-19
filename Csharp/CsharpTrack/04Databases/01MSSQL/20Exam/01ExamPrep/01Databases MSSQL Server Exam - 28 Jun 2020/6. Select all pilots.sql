SELECT * 
	FROM Colonists

	SELECT C.Id AS 'id',c.FirstName+ ' ' + c.LastName AS 'full_name'
	FROM TravelCards AS TC
	JOIN Colonists AS C ON C.Id=TC.ColonistId
	WHERE TC.JobDuringJourney = 'Pilot'
	ORDER BY C.Id