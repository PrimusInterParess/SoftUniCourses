
SELECT A.Id,A.Email,C.Name,COUNT(H.CityId)
	FROM Accounts AS A
		JOIN Hotels AS H ON H.CityId = A.CityId
			JOIN Cities AS C ON C.Id = H.CityId
			GROUP BY H.CityId,A.Id,A.Email,C.Name


			SELECT A.Id,A.Email,C.Name
				FROM Accounts AS A
				JOIN Cities AS C ON C.Id = A.CityId 
					JOIN Hotels AS H ON H.CityId = A.CityId
						JOIN AccountsTrips AS AC ON AC.AccountId=A.Id
				ORDER BY A.Id DESC

				SELECT C.Name,COUNT(A.Id)
				FROM AccountsTrips AS AC
					JOIN Accounts AS A ON A.Id = AC.AccountId
						JOIN Trips AS T ON T.Id= AC.TripId
							JOIN Hotels AS H ON H.CityId = A.CityId
							JOIN Cities AS C ON C.Id=H.CityId
							GROUP BY H.Name,C.Name

							SELECT 
								FROM Accounts AS A
									JOIN AccountsTrips AS AC ON AC.AccountId = A.Id
										JOIN Trips AS T ON T.Id=AC.TripId
											JOIN Cities AS C ON C.Id = A.CityId
												JOIN Hotels  AS H ON H.CityId= A.CityId



					SELECT a.Id,a.Email,c.Name,COUNT(T.Id)
						FROM Accounts AS A
							JOIN Cities AS C ON A.CityId=C.Id
								JOIN Hotels AS H ON H.CityId=A.CityId
									JOIN Rooms AS R ON R.HotelId =H.Id
										JOIN Trips AS T ON T.RoomId = R.Id
											JOIN AccountsTrips AS AC ON AC.AccountId = A.Id
												WHERE A.CityId=H.CityId
						GROUP BY A.Id,A.Email,C.Name





