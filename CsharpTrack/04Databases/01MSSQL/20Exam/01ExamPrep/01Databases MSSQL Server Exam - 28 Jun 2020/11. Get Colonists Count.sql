CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS int
AS
begin
	return (select COUNT(C.Id)
					FROM Colonists AS C
						JOIN TravelCards AS TC ON TC.ColonistId=C.Id
							JOIN Journeys AS J ON J.Id = TC.JourneyId
								JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
									JOIN Planets AS P ON P.Id = SP.PlanetId
					GROUP BY P.Id,P.Name
					HAVING P.Name = @PlanetName)
end

GO
SELECT 
* FROM Planets

				--COUNT(C.FirstName),P.Name
				--	FROM Colonists AS C
				--		JOIN TravelCards AS TC ON TC.ColonistId=C.Id
				--			JOIN Journeys AS J ON J.Id = TC.JourneyId
				--				JOIN Spaceports AS SP ON SP.Id=J.DestinationSpaceportId
				--					JOIN Planets AS P ON P.Id= SP.PlanetId
				--	GROUP BY P.Id,P.Name

				select COUNT(C.Id)
					FROM Colonists AS C
						JOIN TravelCards AS TC ON TC.ColonistId=C.Id
							JOIN Journeys AS J ON J.Id = TC.JourneyId
								JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
									JOIN Planets AS P ON P.Id = SP.PlanetId
				GROUP BY P.Id
				--HAVING P.Name = 'Suthiyclite'

					SELECT COUNT(*)
		FROM Planets AS p
		JOIN Spaceports AS sp ON sp.PlanetId = p.Id
		JOIN Journeys AS j ON j.DestinationSpaceportId = sp.Id
		JOIN TravelCards AS t ON t.JourneyId = j.Id

SELECT dbo.udf_GetColonistsCount('Otroyphus')

go

CREATE FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS int
AS
begin
	return (select COUNT(*)
					FROM Colonists AS C
						JOIN TravelCards AS TC ON TC.ColonistId=C.Id
							JOIN Journeys AS J ON J.Id = TC.JourneyId
								JOIN Spaceports AS SP ON SP.Id = J.DestinationSpaceportId
									JOIN Planets AS P ON P.Id = SP.PlanetId
				WHERE P.Name = @PlanetName)
end

GO