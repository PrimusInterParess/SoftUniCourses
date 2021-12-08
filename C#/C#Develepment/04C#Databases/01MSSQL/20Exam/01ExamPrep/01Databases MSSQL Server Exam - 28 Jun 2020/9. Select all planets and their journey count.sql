SELECT P.Name AS 'PlanetName',COUNT(S.Name) AS 'JourneyCount'
	FROM Journeys AS J
		JOIN Spaceports AS S ON S.Id = J.DestinationSpaceportId
			JOIN Planets AS P ON P.Id=S.PlanetId
		GROUP BY P.Name
	ORDER BY COUNT(S.Name) DESC,P.Name