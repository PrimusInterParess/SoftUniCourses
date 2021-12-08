
SELECT 
T.Id,
A.FirstName + ' '+ ISNULL(A.MiddleName+' ','')+A.LastName AS [Full Name],
C.[Name] AS [From],
TOW.[Name] AS [To],
CASE
	WHEN T.CancelDate IS NULL THEN CAST(DATEDIFF(DAY,T.ArrivalDate,T.ReturnDate)  AS VARCHAR) +' '+'days'
	ELSE 'Canceled' 
END
AS [Duration]
	FROM AccountsTrips AS AC
		JOIN Accounts AS A ON A.Id=AC.AccountId
			JOIN Trips AS T ON T.Id=AC.TripId
				JOIN Cities AS C ON C.Id=A.CityId
					JOIN Trips AS TR ON TR.Id=AC.TripId
						JOIN Rooms AS R ON R.Id=TR.RoomId
							JOIN Hotels AS H ON H.Id = R.HotelId
								JOIN Cities AS TOW ON TOW.Id=H.CityId
	ORDER BY [Full Name],T.Id
			

		SELECT  t.Id,
		CONCAT(a.FirstName,' ',ISNULL(a.MiddleName + ' ',''),a.LastName) AS FullName,
		accountCity.Name AS [From],
		hotelCity.Name AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
		ELSE
			CONCAT(DATEDIFF(DAY,t.ArrivalDate,t.ReturnDate),' days')		
		END
	FROM Trips as t
	JOIN AccountsTrips AS at ON at.TripId = t.Id
	JOIN Accounts AS a ON a.Id = at.AccountId
	JOIN Cities AS accountCity ON accountCity.Id = a.CityId
	JOIN Rooms AS r ON r.Id = t.RoomId
	JOIN Hotels AS h ON h.Id = r.HotelId
	JOIN Cities AS hotelCity ON hotelCity.Id = h.CityId
ORDER BY FullName,t.Id
				
		