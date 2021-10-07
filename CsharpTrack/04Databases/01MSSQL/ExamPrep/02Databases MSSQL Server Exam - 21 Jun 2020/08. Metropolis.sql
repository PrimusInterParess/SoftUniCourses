

SELECT top(10) c.Id,C.Name,c.CountryCode,COUNT(A.Id)
	FROM Accounts AS A
		JOIN Cities AS C ON C.Id = A.CityId
			GROUP BY C.Name,c.Id,c.CountryCode
			order by COUNT(A.Id) desc

			SELECT top(10) C.Id,C.Name,C.CountryCode,COUNT(A.Id) as Accounts
				FROM Cities AS C
					JOIN Accounts AS A ON A.CityId=C.Id
					GROUP BY C.Id,C.Name,C.CountryCode
					ORDER BY Accounts desc



SELECT A.Id,A.Email,C.Name,COUNT(AC.AccountId)
	FROM
		Cities AS C 
		JOIN Hotels AS H ON H.CityId=C.Id
			JOIN Rooms AS R ON R.HotelId=H.Id
				JOIN Trips AS T ON T.RoomId= R.Id
					JOIN AccountsTrips AS AC ON AC.TripId = T.Id
						JOIN Accounts AS A ON A.Id = AC.AccountId
	WHERE C.Id = A.CityId
	GROUP BY C.Name,A.Id,A.Email
	
	