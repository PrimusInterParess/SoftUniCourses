
select count(*)
	FROM TravelCards AS TC
	JOIN Colonists AS C ON C.Id=TC.ColonistId
	JOIN Journeys AS J ON J.Id = TC.JourneyId
		WHERE J.Purpose = 'technical'

		SELECT *
			FROM Journeys