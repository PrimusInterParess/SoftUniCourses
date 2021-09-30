SELECT S.Name,S.Manufacturer
	FROM TravelCards AS TC 
		JOIN Colonists AS C ON C.Id=TC.ColonistId
		JOIN Journeys AS J ON J.Id = TC.JourneyId
	JOIN Spaceships AS S ON S.Id = J.SpaceshipId
	WHERE TC.JobDuringJourney ='PILOT' AND DATEDIFF(YEAR,C.BirthDate,'2019-01-01')<30
	ORDER BY S.Name


	SELECT DATEDIFF(YEAR,'1993-09-16','01/01/2019')

	SELECT BirthDate
	FROM Colonists